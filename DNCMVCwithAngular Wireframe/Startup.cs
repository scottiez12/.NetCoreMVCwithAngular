using DNCMVCwithAngular_Wireframe.Data;
using DNCMVCwithAngular_Wireframe.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DNCMVCwithAngular_Wireframe
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //add service for DbContext
            //one way to do this is...
            //services.AddDbContext<DataContext>(
            //    //tell it which kind of database we're going to use (local for testing, Sql, NoSql, MySql, etc.)
            //    cfg =>
            //    {
            //        cfg.UseSqlServer();
            //    }
            //    );

            //add identity
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
                //cfg.Password.
            })
                .AddEntityFrameworkStores<DataContext>();

            //adding authentication
            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Token:Issuer"],
                        ValidAudience = _config["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:Key"]))
                    };
                });

            //the other way is to leave this service, and go add an override in the DbContext class constructor.. so in our case over in DataContext.cs
            services.AddDbContext<DataContext>();

            //adding our created services
            services.AddTransient<Seeder>();
            //add automapper... this is just the order where it is in the demo.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddTransient<IMailService, NullMailService>();
            //configure what services the server needs for its' middleware
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                //add Microsoft.AspNetCore.Mvc.NewtonsoftJson 
                //this lets us deal with circular/recursive dependencies between entites for EF core
                //then add and configure...
                .AddNewtonsoftJson(cfg =>
                cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                );

            //add the service for razor pages, so the "pages" folder cshtml's can be accessed as a direct url.. like the "/error" page down below
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //use the IWebHostEnvironment variable above to decide if we're in dev or production or staging or whatever
            if (env.IsDevelopment())
            {
                //this shows detailed info on errors
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //catch exception, log it, and go to specific path
                app.UseExceptionHandler("/error");
            }


            //this first ensures that all our js/css/img/whatever files get loaded first
            app.UseStaticFiles();

            //allows us to route individual calls that come into the server to individual pieces of code
            app.UseRouting();

            //for identity ---- THIS ORDER IS IMPORTANT..
            app.UseAuthentication();
            app.UseAuthorization();
            //by using endpoints, we can tell the routes where to go
            app.UseEndpoints(cfg =>
            {
                //this needs to be added to "opt in" to using razor pages
                //so it looks for it by the default name == view relationship
                cfg.MapRazorPages();


                //so this sets up the pattern and default behavior
                cfg.MapControllerRoute("Default",
                    //this below means that it will go by controller => the action/method from the controller => optionally (by adding the '?') an ID in the URL
                    "/{controller}/{action}/{id?}",
                    //this anon object specifys default behavior... so if the request is just /{controller}, then go to the default instead of crashing, or whatever
                    new { controller = "App", action = "Index" });
            });

        }
    }
}

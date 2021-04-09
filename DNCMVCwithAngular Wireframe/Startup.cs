using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //configure what services the server needs for its' middleware
            services.AddControllersWithViews();

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


            //this first ensures that all our js/css/img/whatever files get loaded first
            app.UseStaticFiles();

            //allows us to route individual calls that come into the server to individual pieces of code
            app.UseRouting();

            //by using endpoints, we can tell the routes where to go
            app.UseEndpoints(cfg =>
            {
                //so this sets up the pattern and default behavior
                cfg.MapControllerRoute("Default",
                    //this below means that it will go by controller => the action/method from the controller => optionally an ID in the URL
                    "/{controller}/{action}/{id?}",
                    //this anon object specifys default behavior... so if the request is just /{controller}, then go to the default instead of crashing, or whatever
                    new { controller = "App", action = "Index" });
            });

        }
    }
}

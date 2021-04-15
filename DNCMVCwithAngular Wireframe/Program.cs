using DNCMVCwithAngular_Wireframe.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //so this is how/where they go about seeding
            var host = BuildWebHost(args);

            if (args.Length == 1 && args[0].ToLower() == "/seed")
            {
                RunSeeding(host);
            }
            else
            {
                host.Run();
            }

            //CreateHostBuilder(args).Build().Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<Seeder>();
                seeder.SeedAsync().Wait();
            }

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
            .Build();

        //this is from the main generated source code... for some reason he's not using it..

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        //add the manual configuration here
        //        //once you type this out, use ctrl + .  and autogenerate a method off of AddConfiguration
        //        .ConfigureAppConfiguration(AddConfiguration)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        //private static void AddConfiguration(HostBuilderContext ctx, IConfigurationBuilder bldr)
        //{
        //    //fix the names of the variables and start adding the config info
        //    //ORDER HERE DOES MATTER. SO WHATEVER IS LAST WILL OVERRIDE ANYTHING ABOVE IF THEY SHARE THE SAME DATA / KVP'S.

        //    //clear all existing providers (any app config settings)
        //    bldr.Sources.Clear();

        //    //start building/adding the dependencies
        //    //declare base path and add any other files 
        //    bldr.SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("config.json", false, true)
        //        //we want that json file to be overrideable.. so we add..
        //        .AddEnvironmentVariables();
        //    //this is particularly useful for cloud deployments... so they say.
        //}

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }

    }
}

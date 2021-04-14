using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //add the manual configuration here
                //once you type this out, use ctrl + .  and autogenerate a method off of AddConfiguration
                .ConfigureAppConfiguration(AddConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddConfiguration(HostBuilderContext ctx, IConfigurationBuilder bldr)
        {
            //fix the names of the variables and start adding the config info
            //ORDER HERE DOES MATTER. SO WHATEVER IS LAST WILL OVERRIDE ANYTHING ABOVE IF THEY SHARE THE SAME DATA / KVP'S.

            //clear all existing providers (any app config settings)
            bldr.Sources.Clear();

            //start building/adding the dependencies
            //declare base path and add any other files 
            bldr.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                //we want that json file to be overrideable.. so we add..
                .AddEnvironmentVariables();
            //this is particularly useful for cloud deployments... so they say.
                

        }
    }
}

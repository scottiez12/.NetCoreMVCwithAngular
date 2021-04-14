using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _config;
        //use ctor to add IConfig and generate the field
        //then add it to the "UseSqlServer()" below
        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //you can do it this way, or _config.GetConnectionString()
            //but this way is explicitly calling it from the json file
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DataContextDb"]);
        }
    }
}

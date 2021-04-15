using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class DataContext : IdentityDbContext<StoreUser>
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


        //model builder... in this case for seeding the DB with some default data
        //this could also be used to specify columns/rows and whatnot
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //this is where we can make them
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //you can do it this way, or _config.GetConnectionString()
            //but this way is explicitly calling it from the json file
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DataContextDb"]);
        }
    }
}

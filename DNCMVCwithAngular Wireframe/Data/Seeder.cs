using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class Seeder
    {
        private readonly DataContext _ctx;
        private readonly IWebHostEnvironment _env;

        public Seeder(DataContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public void Seed()
        {
            //ensures that the database does exist.. so yeah.
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                //then we need to create sample data
                //bring in IWebHostEnvironment into the ctor
                var filePath = Path.Combine(_env.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                _ctx.Products.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };

                _ctx.SaveChanges();
            }
        }

    }
}

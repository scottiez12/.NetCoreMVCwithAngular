using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<StoreUser> _userManager;

        public Seeder(DataContext ctx, IWebHostEnvironment env, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _env = env;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            //ensures that the database does exist.. so yeah.
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("scott@ziegler.com");
            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Scott",
                    LastName = "Ziegler",
                    Email = "scott@ziegler.com",
                    UserName = "scott@ziegler.com"
                };

                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder.");
                }
            }

            if (!_ctx.Products.Any())
            {
                //then we need to create sample data
                //bring in IWebHostEnvironment into the ctor
                var filePath = Path.Combine(_env.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                var order = _ctx.Orders.Where(x => x.Id == 1).FirstOrDefault();
                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                    //    Product = DateTime.Today,
                    //    OrderNumber = "10000",
                    //    Items = new List<OrderItem>()
                    //{
                    //}
                    //};
                }



                _ctx.SaveChanges();
            }
        }

    }
}

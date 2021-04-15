using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext _ctx;
        private readonly ILogger<ProjectRepository> _logger;

        public ProjectRepository(DataContext ctx, ILogger<ProjectRepository> logger)
        {
            this._ctx = ctx;
            this._logger = logger;
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ctx.Orders.Include(o => o.Items)
                .ThenInclude(p => p.Product)                
                .ToList();
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                     .Include(o => o.Items)
                     .ThenInclude(p => p.Product)
                     .ToList();
            }
            else
            {
                return _ctx.Orders
                    .ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                _logger.LogInformation("Get all Products was called.");
                return _ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all products {ex}");
                return null;
            }
        }

        public Order GetOrderById(int id)
        {
           return _ctx.Orders
                .Include(o => o.Items)
                .ThenInclude(p => p.Product)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return _ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}

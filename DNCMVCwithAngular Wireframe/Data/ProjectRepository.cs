using DNCMVCwithAngular_Wireframe.Data.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DataContext ctx;
        private readonly ILogger<ProjectRepository> logger;

        public ProjectRepository(DataContext ctx, ILogger<ProjectRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("Get all Products was called.");
                return ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all products {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return ctx.Products
                .Where(p => p.Category == category)
                .ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}

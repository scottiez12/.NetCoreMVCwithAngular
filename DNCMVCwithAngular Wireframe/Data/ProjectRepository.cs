using DNCMVCwithAngular_Wireframe.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public class ProjectRepository
    {
        private readonly DataContext ctx;

        public ProjectRepository(DataContext ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ctx.Products
                .OrderBy(p => p.Title)
                .ToList();
        }
    }
}

using DNCMVCwithAngular_Wireframe.Data.Entities;
using System.Collections.Generic;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public interface IProjectRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}
using DNCMVCwithAngular_Wireframe.Data.Entities;
using System.Collections.Generic;

namespace DNCMVCwithAngular_Wireframe.Data
{
    public interface IProjectRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);


        IEnumerable<Order> GetAllOrders();  

        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);


        bool SaveAll();
        void AddEntity(object model);


    }
}
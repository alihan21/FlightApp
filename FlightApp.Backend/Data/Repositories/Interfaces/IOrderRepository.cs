using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void AddNewOrder(Order order);
        Order GetById(int orderId);
        Order GetLastOrder();
        IEnumerable<Order> RetrieveAllOrdersByUserId(int userId);
        IEnumerable<Order> GetAll();
        void RemoveOrderById(int orderId);
        void SaveChanges();
    }
}

using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IOrderHistoryRepository
    {
        IEnumerable<OrderHistory> GetAll();
        IEnumerable<OrderHistory> GetUserOrderHistory(int passengerId);
        void Add(OrderHistory orderHistory);
        void SaveChanges();
    }
}

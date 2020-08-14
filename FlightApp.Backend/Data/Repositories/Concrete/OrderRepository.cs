using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _orders;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _orders = dbContext.Orders;
        }

        public void AddNewOrder(Order order)
        {
            _orders.Add(order);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders
                .Include(o => o.Passenger)
                .ThenInclude(p => p.Seat)
                .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Food);
        }

        public Order GetById(int orderId)
        {
            return _orders
                .Include(o => o.OrderLines)
                .SingleOrDefault(o => o.OrderId == orderId);
        }

        public Order GetLastOrder()
        {
            return _orders.Last();
        }

        public void RemoveOrderById(int orderId)
        {
            _orders.Remove(GetById(orderId));
        }

        public IEnumerable<Order> RetrieveAllOrdersByUserId(int userId)
        {
            return _orders
                .Include(o => o.OrderLines)
                .Where(o => o.Passenger.UserId == userId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

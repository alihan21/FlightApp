using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<OrderHistory> _orderHistories;

        public OrderHistoryRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _orderHistories = dbContext.OrderHistories;
        }

        public void Add(OrderHistory orderHistory)
        {
            _orderHistories.Add(orderHistory);
        }

        public IEnumerable<OrderHistory> GetAll()
        {
            return _orderHistories;
        }

        public IEnumerable<OrderHistory> GetUserOrderHistory(int passengerId)
        {
            return _orderHistories.Where(oh => oh.PassengerId == passengerId);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

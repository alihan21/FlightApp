using System.Collections.Generic;
using System.Linq;
using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
  public class OrderFoodRepository : IOrderFoodRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Passenger> _passengers;

    public OrderFoodRepository(ApplicationDbContext dbContext)
    {
      _context = dbContext;
      _passengers = dbContext.Passengers;
    }

    public IEnumerable<OrderFood> GetOrderHistoryOfUser(int userId)
    {
      List<OrderFood> orders = new List<OrderFood>();

      var foundPassenger = _passengers
        .Include(p => p.Orders)
        .ThenInclude(o => o.Orders)
        .ThenInclude(of => of.Food)
        .SingleOrDefault(p => p.UserId == userId);

      foundPassenger?.Orders?
        .ForEach(o => o.Orders
        .ForEach(of => orders.Add(of)));

      return orders;
    }
  }
}

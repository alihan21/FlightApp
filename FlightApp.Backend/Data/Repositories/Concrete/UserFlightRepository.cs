using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
  public class UserFlightRepository : IUserFlightRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<UserFlight> _userFlights;

    public UserFlightRepository(ApplicationDbContext dbContext)
    {
      _context = dbContext;
      _userFlights = dbContext.UserFlights;
    }

    public UserFlight GetUserFlightByUserId(int userId)
    {
      return _userFlights
        .Include(uf => uf.Flight)
        .ThenInclude(f => f.Plane)
        .Where(uf => uf.UserId == userId).LastOrDefault();
    }
  }
}

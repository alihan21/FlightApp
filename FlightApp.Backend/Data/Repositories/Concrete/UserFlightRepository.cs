using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<Passenger> GetAllPassengersByFlightId(string flightId)
        {
            return _userFlights
                .Include(uf => uf.User)
                .ThenInclude(u => u.Seat)
                .Where(uf => uf.FlightId == flightId && uf.User is Passenger)
                .Select(uf => (Passenger)uf.User);
        }

        public UserFlight GetUserFlightByUserId(int userId)
        {
            return _userFlights
              .Include(uf => uf.User)
              .Include(uf => uf.Flight)
              .ThenInclude(f => f.Plane)
              .Where(uf => uf.UserId == userId).LastOrDefault();
        }
    }
}

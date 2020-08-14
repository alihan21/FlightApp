using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Passenger> _passengers;
        private readonly DbSet<UserFlight> _userFlights;

        public PassengerRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _passengers = dbContext.Passengers;
            _userFlights = dbContext.UserFlights;
        }

        public Passenger GetByFlightIdAndSeatNumber(string flightId, string seatNumber)
        {
            var currentFlight = _userFlights
                .Include(uf => uf.User)
                .ThenInclude(u => u.Seat)
                .SingleOrDefault(uf => uf.FlightId == flightId && uf.User.Seat.SeatNumber == seatNumber);

            return (Passenger)currentFlight?.User;
        }

        public Passenger GetByName(string name)
        {
            return _passengers.SingleOrDefault(p => p.Name == name);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

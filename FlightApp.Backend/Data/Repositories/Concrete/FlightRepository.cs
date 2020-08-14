using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Flight> _flights;

        public FlightRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _flights = dbContext.Flights;
        }

        public IEnumerable<Flight> GetAll()
        {
            return _flights;
        }

        public Flight GetBy(string id)
        {
            return _flights.Include(f => f.Plane).ThenInclude(p => p.Seats).SingleOrDefault(r => r.FlightId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

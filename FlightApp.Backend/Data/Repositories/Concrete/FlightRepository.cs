using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Flight GetBy(int id)
        {
           return  _flights.SingleOrDefault(r => r.FlightId == id);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

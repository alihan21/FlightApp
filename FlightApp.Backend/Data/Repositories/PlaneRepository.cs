using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {

        private readonly FlightAppContext _context;
        private readonly DbSet<Plane> _planes;

        public PlaneRepository(FlightAppContext dbContext)
        {
            _context = dbContext;
            _planes = dbContext.Planes;
        }

        public IEnumerable<Plane> GetAll()
        {
            return _planes.Include(r => r.Seats);
        }

        public Plane GetBy(int id)
        {
            return _planes.Include(r => r.Seats).SingleOrDefault(r => r.PlaneId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

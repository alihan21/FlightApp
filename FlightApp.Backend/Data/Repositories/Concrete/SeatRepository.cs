using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class SeatRepository : ISeatRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Seat> _seats;

        public SeatRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _seats = dbContext.Seats;
        }

        public IEnumerable<Seat> GetAll()
        {
            return _seats;
        }

        public IEnumerable<Seat> GetByPlaneId(int planeId)
        {
            return _seats.Where(r => r.Plane.PlaneId == planeId).ToList();
        }

        public Seat GetBy(int id)
        {
            return _seats.SingleOrDefault(r => r.SeatId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

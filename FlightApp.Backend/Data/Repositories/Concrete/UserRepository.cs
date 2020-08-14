using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;
        private readonly DbSet<UserFlight> _userFlights;
        private readonly DbSet<Passenger> _passengers;


        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users;
            _userFlights = dbContext.UserFlights;
        }

        public IEnumerable<User> GetAll()
        {
            return _users
              .Include(u => u.Seat)
              .Include(u => u.UserFlights);
        }

        public User GetBySeatNumber(string flightId, string seatNumber)
        {
            var currentFlight = _userFlights
                .Include(uf => uf.User)
                .ThenInclude(u => u.Seat)
                .SingleOrDefault(uf => uf.FlightId == flightId && uf.User.Seat.SeatNumber == seatNumber);

            return currentFlight.User;
        }

        public User GetPassengerById(int id)
        {
            return _users
              .Where(u => !(u is Staff))
              .Include(u => u.UserFlights)
              .SingleOrDefault(u => u.UserId == id);
        }

        public Passenger GetPassengerByIdWithChannel(int id)
        {
            return _passengers.SingleOrDefault(u => u.UserId == id);
        }

        public User GetStaffById(int id)
        {
            return _users
              .Where(u => !(u is Passenger))
              .SingleOrDefault(u => u.UserId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}

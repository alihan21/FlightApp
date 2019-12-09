using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _users = dbContext.Users;
        }



        public IEnumerable<User> GetAll()
        {
            return _users.Include(u => u.Seat).Include(u => u.UserFlights);
        }

        public User GetBy(int id)
        {
            return _users.SingleOrDefault(r => r.UserId == id);
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

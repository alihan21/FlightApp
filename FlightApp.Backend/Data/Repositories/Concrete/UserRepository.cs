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

    public UserRepository(ApplicationDbContext dbContext)
    {
      _context = dbContext;
      _users = dbContext.Users;
    }

    public IEnumerable<User> GetAll()
    {
      return _users
        .Include(u => u.Seat)
        .Include(u => u.UserFlights);
    }

    public User GetBySeatNumber(string seatNumber, int planeId)
    {
      return _users
        .Include(u => u.Seat)
        .ThenInclude(s => s.Plane)
        .SingleOrDefault(u => u.Seat.SeatNumber == seatNumber && u.Seat.Plane.PlaneId == planeId);
    }

    public User GetPassengerById(int id)
    {
      return _users
        .Where(u => !(u is Staff))
        .SingleOrDefault(u => u.UserId == id);
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

using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
  public class StaffRepository : IStaffRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Staff> _staff;

    public StaffRepository(ApplicationDbContext dbContext)
    {
      _context = dbContext;
      _staff = dbContext.FlightStaff;
    }

    public Staff GetByLoginCode(int loginCode)
    {
      return _staff.SingleOrDefault(s => s.LoginCode == loginCode);
    }
  }
}

using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Concrete
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Food> _foods;

        public FoodRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _foods = dbContext.Foods;
        }

        public IEnumerable<Food> GetAll()
        {
            return _foods;
        }

        public Food GetById(int id)
        {
            return _foods.SingleOrDefault(r => r.FoodId == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IFoodRepository
    {
        Food GetById(int id);

        IEnumerable<Food> GetAll();

        void SaveChanges();
    }
}

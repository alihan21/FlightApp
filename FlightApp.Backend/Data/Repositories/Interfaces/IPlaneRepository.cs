using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IPlaneRepository
    {

        Plane GetBy(int id);

        IEnumerable<Plane> GetAll();

        void SaveChanges();
    }
}

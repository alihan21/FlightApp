using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public interface IPlaneRepository
    {

        Plane GetBy(int id);

        IEnumerable<Plane> GetAll();

        void Add(Plane plane);

        void Update(Plane plane);

        void SaveChanges();
    }
}

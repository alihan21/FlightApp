using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public interface IFlightRepository
    {
        Flight GetBy(int id);

        IEnumerable<Flight> GetAll();

        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public interface ISeatRepository
    {
        Seat GetBy(int id);

        IEnumerable<Seat> GetAll();

        void SaveChanges();
    }
}

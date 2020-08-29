using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface ISeatRepository
    {
        Seat GetBy(int id);

        IEnumerable<Seat> GetByPlaneId(int planeId);

        IEnumerable<Seat> GetAll();

        void SaveChanges();
    }
}

using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IPassengerRepository
    {
        Passenger GetById(int passengerId);
        IEnumerable<Passenger> GetAll();
        Passenger GetByName(string name);
        Passenger GetByFlightIdAndSeatNumber(string flightId, string seatNumber);
        void SaveChanges();
    }
}

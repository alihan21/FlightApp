using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IUserFlightRepository
    {
        UserFlight GetUserFlightByUserId(int userId);
        IEnumerable<Passenger> GetAllPassengersByFlightId(string flightId);
    }
}
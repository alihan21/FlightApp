using FlightApp.Backend.Models.Domain;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IPassengerRepository
    {
        Passenger GetByName(string name);
        Passenger GetByFlightIdAndSeatNumber(string flightId, string seatNumber);
        void SaveChanges();
    }
}

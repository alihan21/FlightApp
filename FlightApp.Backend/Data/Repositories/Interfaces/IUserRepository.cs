using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetPassengerById(int id);
        Passenger GetPassengerByIdWithChannel(int id);
        User GetStaffById(int id);
        User GetBySeatNumber(string flightId, string seatNumber);
        IEnumerable<User> GetAll();
        void Update(User user);
        void SaveChanges();
    }
}

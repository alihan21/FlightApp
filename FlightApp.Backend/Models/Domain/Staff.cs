using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Staff : User
    {
        public int LoginCode { get; set; }
        public void MovePassengerToAnotherSeat(Passenger passenger, Seat seat)
        {
            passenger.Seat = seat;
        }
    }
}

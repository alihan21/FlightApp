namespace FlightApp.Backend.Models.Domain
{
    public class FlightStaff : User
    {
        public int LoginId { get; set; }
        public Flight Flight { get; set; }

        public void MovePassengerToAnotherSeat(Passenger passenger, Seat seat)
        {
            passenger.Seat = seat;
        }
    }
}

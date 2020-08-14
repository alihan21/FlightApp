using FlightApp.Frontend.Models;

namespace FlightApp.Frontend.ViewModels
{
    public class PassengerViewModel : UserViewModel
    {
        public string FlightId { get; set; }
        public string SeatNumber { get; set; }

        public PassengerViewModel()
        {

        }

        public PassengerViewModel(Passenger passenger)
        {
            Name = passenger.Name;
            Id = passenger.UserId;
        }

        public PassengerViewModel(Passenger passenger, string flightId, string seatNumber)
        {
            Name = passenger.Name;
            Id = passenger.UserId;
            FlightId = flightId;
            SeatNumber = seatNumber;
        }
    }
}

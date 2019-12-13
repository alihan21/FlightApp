using FlightApp.Frontend.Models;

namespace FlightApp.Frontend.ViewModels
{
  public class PassengerViewModel : UserViewModel
  {
    public PassengerViewModel()
    {

    }

    public PassengerViewModel(Passenger passenger)
    {
      Name = passenger.Name;
      Id = passenger.UserId;
    }
  }
}

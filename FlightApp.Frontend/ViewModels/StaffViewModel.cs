using FlightApp.Frontend.Models;

namespace FlightApp.Frontend.ViewModels
{
  public class StaffViewModel : UserViewModel
  {
    public StaffViewModel()
    {

    }

    public StaffViewModel(Staff staff)
    {
      Name = staff.Name;
    }
  }
}

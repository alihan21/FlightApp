using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
{
  public class UserFlight
  {
    public int UserId { get; set; }
    public User User { get; set; }
    public string FlightId { get; set; }
    public Flight Flight { get; set; }

    public UserFlight(User user, Flight flight)
    {
      User = user;
      UserId = user.UserId;
      Flight = flight;
      FlightId = flight.FlightId;
    }

    protected UserFlight()
    {

    }
  }
}

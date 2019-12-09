using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
{
  public class User
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public List<UserFlight> UserFlights { get; set; }

    public User(string name)
    {
      Name = name;
      UserFlights = new List<UserFlight>();
    }

    protected User()
    {
      UserFlights = new List<UserFlight>();
    }

    public void AddToFlight(UserFlight userFlight)
    {
      UserFlights.Add(userFlight);
    }

    public void RemoveToFlight(UserFlight userFlight)
    {
      UserFlights.Remove(userFlight);
    }
  }
}

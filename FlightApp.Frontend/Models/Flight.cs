using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.Models
{
  public class Flight
  {
    public string FlightId { get; set; }
    public string Destination { get; set; }
    public string Origin { get; set; }
    public double FlightDuration { get; set; }
    public DateTime TimeOfDepart { get; set; }
    public List<UserFlight> Attendances { get; set; }
    public Plane Plane { get; set; }

    public Flight(string destination, string origin, double flightDuration, DateTime timeOfDepart, Plane plane)
    {
      Destination = destination;
      Origin = origin;
      FlightDuration = flightDuration;
      TimeOfDepart = timeOfDepart;
      Plane = plane;
    }

    protected Flight()
    {
      Attendances = new List<UserFlight>();
    }
  }
}

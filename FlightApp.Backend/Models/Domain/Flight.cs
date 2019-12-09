using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Flight
  {
    public int FlightId { get; set; }
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

    public void AddUserToFlight(UserFlight user)
    {
      Attendances.Add(user);
    }

    public void RemoveUserFromFlight(UserFlight user)
    {
      Attendances.Remove(user);
    }
  }
}

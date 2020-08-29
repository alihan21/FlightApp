using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Plane
  {
    public int PlaneId { get; set; }
    public int MaxSeats { get; set; }
    public string Name { get; set; }
    public List<Seat> Seats { get; set; }
    [JsonIgnore]
    public List<Flight> PlaneFlights { get; set; }

    public Plane(string name, int maxSeats)
    {
      Name = name;
      MaxSeats = maxSeats;
      Seats = new List<Seat>();
      PlaneFlights = new List<Flight>();
    }

    protected Plane()
    {
      Seats = new List<Seat>();
      PlaneFlights = new List<Flight>();
    }

    public void AddSeat(Seat seat)
    {
      Seats.Add(seat);
    }

    public void RemoveSeat(Seat seat)
    {
      Seats.Remove(seat);
    }

    public void AddPlaneFlight(Flight flight)
    {
      PlaneFlights.Add(flight);
    }

    public void RemovePlaneFlight(Flight flight)
    {
      PlaneFlights.Remove(flight);
    }
  }
}

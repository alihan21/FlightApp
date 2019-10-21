using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Plane
    {
        public int PlaneId { get; set; }
        public int MaxSeats { get; set; }
        public string Name { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Flight> PlaneFlights { get; set; }
    }
}

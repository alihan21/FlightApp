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
        public List<UserFlight> UserFlights { get; set; }
        public Plane Plane { get; set; }
    }
}

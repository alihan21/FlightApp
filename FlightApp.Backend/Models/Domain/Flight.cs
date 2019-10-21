using System;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Origin { get; set; }
        public int FlightDuration { get; set; }
        public DateTime TimeOfDepart { get; set; }
        public List<PassengerFlight> Passengers { get; set; }
        //I dont know if this guy should be here. Do we need him
        //public List<FlightStaff> FlightStaff { get; set; }
    }
}

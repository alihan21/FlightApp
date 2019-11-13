using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Passenger : User
    {
        public Seat Seat { get; set; }
        public List<Order> Orders { get; set; }
    }
}

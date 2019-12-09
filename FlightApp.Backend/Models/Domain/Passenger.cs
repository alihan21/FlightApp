using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Passenger : User
    {
        public List<Order> Orders { get; set; }
    }
}

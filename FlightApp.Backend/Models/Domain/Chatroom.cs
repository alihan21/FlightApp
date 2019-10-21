using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Chatroom
    {
        public string Logincode { get; set; }
        public List<Passenger> Users { get; set; }
    }
}

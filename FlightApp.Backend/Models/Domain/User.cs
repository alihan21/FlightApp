using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<UserFlight> UserFlights { get; set; }

    }
}

using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<UserFlight> UserFlights { get; set; }
        public Seat Seat { get; set; }

        public User(string name)
        {
            Name = name;
            UserFlights = new List<UserFlight>();
        }

        protected User()
        {
            UserFlights = new List<UserFlight>();
        }

        public void AddFlight(UserFlight userFlight)
        {
            UserFlights.Add(userFlight);
        }

        public void RemoveFlight(UserFlight userFlight)
        {
            UserFlights.Remove(userFlight);
        }
    }
}

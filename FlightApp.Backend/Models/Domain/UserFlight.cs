﻿namespace FlightApp.Backend.Models.Domain
{
    public class UserFlight
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
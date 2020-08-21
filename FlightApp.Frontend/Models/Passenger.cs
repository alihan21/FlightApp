using System.Collections.Generic;

namespace FlightApp.Frontend.Models
{
    public class Passenger : User
    {
        public int ChannelId { get; set; }
        public List<Order> Orders { get; set; }
        public Notification Notification { get; set; }
        public bool IsNotificationRead { get; set; }

        public Passenger(Seat seat, string name) : base(name)
        {
            Seat = seat;
            Orders = new List<Order>();
        }

        public Passenger()
        {
            Orders = new List<Order>();
        }
    }
}
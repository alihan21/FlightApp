using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public int ChannelId { get; set; }
        public Passenger Passenger { get; set; }

        public Message()
        {

        }

        public Message(Passenger passenger, string text)
        {
            Text = text;
            Passenger = passenger;
            ChannelId = passenger.ChannelId;
        }
    }
}

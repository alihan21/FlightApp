using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public class Channel
    {
        public int ChannelId { get; set; }
        public ICollection<Message> Messages { get; set; }

        public Channel()
        {
            Messages = new List<Message>();
        }

        public void addMessage(Passenger passenger, string text)
        {
            Message message = new Message(passenger, text);
            Messages.Add(message);
        }
    }
}

using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.DTO
{
    public class MessageDTO
    {

        public int MessageId { get; set; }
        public string Text { get; set; }
        public string PassengerName { get; set; }

        public MessageDTO()
        {

        }

        public MessageDTO(Message message)
        {
            MessageId = message.MessageId;
            Text = message.Text;
            PassengerName = message.Passenger.Name;
        }
    }
}

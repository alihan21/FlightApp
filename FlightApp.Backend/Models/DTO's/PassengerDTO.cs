using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Backend.Models.Domain;

namespace FlightApp.Backend.Models.DTO_s
{
    public class PassengerDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Seat Seat { get; set; }

        public PassengerDTO(Passenger passenger)
        {
            UserId = passenger.UserId;
            Name = passenger.Name;
            Seat = passenger.Seat;
        }
    }
}

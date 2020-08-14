using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.DTO_s
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public PassengerDTO Passenger { get; set; }

        public List<OrderLineDTO> OrderLines { get; set; }

        public OrderDTO(Order order)
        {
            OrderLines = new List<OrderLineDTO>();

            OrderId = order.OrderId;
            Passenger = new PassengerDTO(order.Passenger);
            foreach(OrderLine orderLine in order.OrderLines)
            {
                OrderLineDTO orderLineDTO = new OrderLineDTO(orderLine);
                OrderLines.Add(orderLineDTO);
            }
        }
    }
}

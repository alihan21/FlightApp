using FlightApp.Backend.Models.Domain;

namespace FlightApp.Backend.Models.DTO_s
{
    public class OrderLineDTO
    {
        public int OrderId { get; set; }
        public Food Food { get; set; }
        public int Quantity { get; set; }

        public OrderLineDTO()
        {

        }

        public OrderLineDTO(OrderLine orderLine)
        {
            OrderId = orderLine.OrderId;
            Food = orderLine.Food;
            Quantity = orderLine.Quantity;
        }
    }
}

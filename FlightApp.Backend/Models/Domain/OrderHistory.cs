using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class OrderHistory
    {
        public int OrderId { get; set; }

        public int FoodId { get; set; }

        public int PassengerId { get; set; }

        public int Quantity { get; set; }

        public OrderHistory(OrderLine orderLine)
        {
            OrderId = orderLine.OrderId;
            FoodId = orderLine.FoodId;
            Quantity = orderLine.Quantity;
        }

        protected OrderHistory()
        {
            
        }
    }
}

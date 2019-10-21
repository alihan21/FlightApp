using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderFood> OrderFoods { get; set; }

        public Order()
        {
            OrderFoods = new List<OrderFood>();
        }
    }
}

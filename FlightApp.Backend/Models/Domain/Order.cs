using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
    public class Order
    {
        public int OrderId { get; set; }

        public Passenger Passenger { get; set; }

        public List<OrderLine> OrderLines { get; }

        public bool IsCompleted { get; set; }

        #region Constructors
        public Order()
        {
            OrderLines = new List<OrderLine>();
            IsCompleted = false;
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }

        public void RemoveOrderLine(OrderLine orderLine)
        {
            OrderLines.Remove(orderLine);
        }
        #endregion
    }
}

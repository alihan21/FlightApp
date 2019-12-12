using System.Collections.Generic;

namespace FlightApp.Frontend.Models
{
  public class Order
  {
    public int OrderId { get; set; }
    public List<OrderFood> Orders { get; set; }

    public Order()
    {
      Orders = new List<OrderFood>();
    }

    public void AddOrder(OrderFood order)
    {
      Orders.Add(order);
    }

    public void RemoveOrder(OrderFood order)
    {
      Orders.Remove(order);
    }
  }
}

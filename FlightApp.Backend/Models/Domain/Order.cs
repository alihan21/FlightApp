using Newtonsoft.Json;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Order
  {
    public int OrderId { get; set; }
    [JsonIgnore]
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

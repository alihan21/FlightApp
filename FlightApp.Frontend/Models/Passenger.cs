using System.Collections.Generic;

namespace FlightApp.Frontend.Models
{
  public class Passenger : User
  {
    public List<Order> Orders { get; set; }

    public Passenger(Seat seat, string name) : base(name)
    {
      Seat = seat;
      Orders = new List<Order>();
    }

    protected Passenger()
    {
      Orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }

    public void RemoveOrder(Order order)
    {
      Orders.Remove(order);
    }
  }
}

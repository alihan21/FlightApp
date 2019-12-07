using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Passenger : User
  {
    public Seat Seat { get; set; }
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

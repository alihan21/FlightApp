using System.Collections.Generic;

namespace FlightApp.Backend.Models.Domain
{
  public class Food
  {
    public int FoodId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public List<OrderFood> FoodHistory { get; set; }

    public Food(string name, string description, string type)
    {
      Name = name;
      Description = description;
      Type = type;
      FoodHistory = new List<OrderFood>();
    }

    protected Food()
    {
      FoodHistory = new List<OrderFood>();
    }

    public void AddToHistory(OrderFood order)
    {
      FoodHistory.Add(order);
    }

    public void RemoveFromHistory(OrderFood order)
    {
      FoodHistory.Remove(order);
    }
  }
}

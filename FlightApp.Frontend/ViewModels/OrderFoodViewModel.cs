using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;

namespace FlightApp.Frontend.ViewModels
{
  public class OrderFoodViewModel
  {
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }

    public OrderFoodViewModel()
    {

    }

    public OrderFoodViewModel(OrderFood orderFood)
    {
      OrderId = orderFood.OrderId;
      Order = orderFood.Order;
      FoodId = orderFood.FoodId;
      Food = orderFood.Food;
    }
  }
}

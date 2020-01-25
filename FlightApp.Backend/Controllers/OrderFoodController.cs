using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FlightApp.Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrderFoodController : ControllerBase
  {
    private readonly IOrderFoodRepository _orderFoodRepository;

    public OrderFoodController(IOrderFoodRepository orderFoodRepository)
    {
      _orderFoodRepository = orderFoodRepository;
    }

    [HttpGet]
    [Route("user/{userId}")]
    public ActionResult<OrderFood> GetOrderHistoryOfUser(int userId)
    {
      var orders = _orderFoodRepository.GetOrderHistoryOfUser(userId);

      if(orders == null || !orders.Any())
      {
        return NotFound();
      }

      return Ok(orders);
    }
  }
}

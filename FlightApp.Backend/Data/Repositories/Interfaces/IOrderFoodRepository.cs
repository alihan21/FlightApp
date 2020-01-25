using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
  public interface IOrderFoodRepository
  {
    IEnumerable<OrderFood> GetOrderHistoryOfUser(int userId);
  }
}

using FlightApp.Backend.Models.Domain;

namespace FlightApp.Backend.Data.Repositories.Interfaces
{
  public interface IUserFlightRepository
  {
    UserFlight GetUserFlightByUserId(int userId);
  }
}

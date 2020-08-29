using FlightApp.Backend.Data;
using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserFlightController : ControllerBase
  {
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserFlightRepository _userFlightRepository;

    public UserFlightController(ApplicationDbContext dbContext, IUserFlightRepository userFlightRepository)
    {
      _dbContext = dbContext;
      _userFlightRepository = userFlightRepository;
    }

    /// <summary>
    /// Get the last flight of user with id
    /// </summary>
    /// <param name="id">the id of </param>
    [HttpGet]
    [Route("user/{userId}")]
    public ActionResult<UserFlight> GetLastFlightOfUserByUserId(int userId)
    {
      var userFlight = _userFlightRepository.GetUserFlightByUserId(userId);

      if(userFlight == null)
      {
        return NotFound();
      }

      return Ok(userFlight);
    }
  }
}

using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightApp.Backend.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class FlightController : Controller
  {
    private readonly IFlightRepository _flightRepository;


    public FlightController(IFlightRepository context)
    {
      _flightRepository = context;
    }
   
    /// <summary>
    /// Get all flights for all users
    /// </summary>
    [HttpGet]
    public IEnumerable<Flight> GetFlights()
    {
      return _flightRepository.GetAll();
    }

    
    /// <summary>
    /// Get a flight by id
    /// </summary>
    /// <param name="id">the id of the flight</param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Flight> GetFlight(int id)
    {
      Flight flight = _flightRepository.GetBy(id);
      if (flight == null)
      {
        return NotFound();
      }

      return Ok(flight);
    }
  }
}

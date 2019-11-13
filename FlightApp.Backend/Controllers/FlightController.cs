using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Backend.Data.Repositories;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;


        public FlightController(FlightRepository context)
        {
            _flightRepository = context;
        }

        [HttpGet]
        public IEnumerable<Flight> GetFlights()
        {
            return _flightRepository.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Flight> GetFlight(int id)
        {
            Flight flight = _flightRepository.GetBy(id);
            if (flight == null) return NotFound();
            return flight;
        }
    }
}
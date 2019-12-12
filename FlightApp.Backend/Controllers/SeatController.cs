using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeatRepository _seatRepository;


        public SeatController(ISeatRepository context)
        {
            _seatRepository = context;
        }

        [HttpGet]
        public IEnumerable<Seat> GetSeats()
        {
            return _seatRepository.GetAll();
        }


        [HttpGet("{id}")]
        public ActionResult<Seat> GetSeat(int id)
        {
            Seat seat = _seatRepository.GetBy(id);
            if (seat == null) return NotFound();
            return seat;
        }

        [HttpGet]
        [Route("plane/{planeId}")]
        public ActionResult<Seat> GetSeatByPlane(int planeId)
        {

            IEnumerable<Seat> seats = _seatRepository.GetByPlaneId(planeId);
            if (seats == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(seats);
            }
        }
    }
}

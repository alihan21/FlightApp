using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IUserFlightRepository _userFlightRepository;
        private readonly IPassengerRepository _passengerRepository;

        public SeatController(ISeatRepository seatRepository, IFlightRepository flightRepository, IUserFlightRepository userFlightRepository, IPassengerRepository passengerRepository)
        {
            _seatRepository = seatRepository;
            _flightRepository = flightRepository;
            _userFlightRepository = userFlightRepository;
            _passengerRepository = passengerRepository;
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

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        [HttpGet]
        [Route("flight/{flightId}/allSeats")]
        public ActionResult<Seat> GetSeatByPlane(string flightId)
        {
            List<Seat> seats = GetAllSeats(flightId);

            if(seats == null)
            {
                return NotFound("Flight not found");
            }

            return Ok(seats);
        }

        [HttpGet]
        [Route("flight/{flightId}/availableSeats")]
        public ActionResult<Seat> GetAvailableSeats(string flightId)
        {
            List<Seat> seats = GetAllSeats(flightId);

            var passengers = _userFlightRepository.GetAllPassengersByFlightId(flightId).ToList();

            List<int> passengerSeatIds = passengers.Select(p => p.Seat.SeatId).ToList();

            seats.RemoveAll(s => passengerSeatIds.Contains(s.SeatId));

            return Ok(seats);
        }

        [HttpPost]
        [Route("flight/{flightId}/seats/change/{oldSeatNumber}/{newSeatNumber}")]
        public ActionResult MovePassengerToAnotherSeat(string flightId, string oldSeatNumber, string newSeatNumber)
        {
            var passengers = _userFlightRepository.GetAllPassengersByFlightId(flightId);

            if (passengers == null)
            {
                return NotFound("Flight not found");
            }

            var seats = GetAllSeats(flightId);

            if(seats == null)
            {
                return NotFound("Flight not found");
            }

            var passenger = passengers
                .SingleOrDefault(p => p.Seat.SeatNumber == oldSeatNumber);

            if (passenger == null)
            {
                return NotFound("Old seat not found");
            }

            var newSeat = seats
                .SingleOrDefault(s => s.SeatNumber == newSeatNumber);

            if(newSeat == null)
            {
                return NotFound("New seat not found");
            }

            passenger.Seat = newSeat;

            _passengerRepository.SaveChanges();

            return Ok();
        }

        private List<Seat> GetAllSeats(string flightId)
        {
            var flight = _flightRepository.GetById(flightId);

            if (flight == null)
            {
                return null;
            }

            return _seatRepository.GetByPlaneId(flight.Plane.PlaneId).ToList();
        }
    }
}

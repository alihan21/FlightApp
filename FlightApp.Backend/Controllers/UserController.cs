using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IStaffRepository _staffRepository;
        private readonly IUserFlightRepository _userFlightRepository;

        public UserController(IUserRepository userRepository, IStaffRepository staffRepository, IUserFlightRepository userFlightRepository)
        {
            _userRepository = userRepository;
            _staffRepository = staffRepository;
            _userFlightRepository = userFlightRepository;
        }


        // GET: api/Users
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _userRepository.GetAll().ToList();

            if (users == null || !users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("passenger/{id}")]
        public ActionResult<User> GetPassengerById(int id)
        {
            User user = _userRepository.GetPassengerById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("flights/{flightId}/passengers/all")]
        public ActionResult<List<Passenger>> GetPassengerById(string flightId)
        {
            var passengers = _userFlightRepository.GetAllPassengersByFlightId(flightId);

            if(passengers == null)
            {
                return NotFound("Passengers not found");
            }

            return Ok(passengers);
        }

        [HttpGet("staff/id/{id}")]
        public ActionResult<User> GetStaffById(int id)
        {
            User user = _userRepository.GetStaffById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("staff/login/{loginCode}")]
        public ActionResult<Staff> GetStaffByLoginCode(int loginCode)
        {
            Staff staff = _staffRepository.GetByLoginCode(loginCode);

            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        /// <summary>
        /// Modifies a user
        /// </summary>
        /// 
        [HttpPut("{id}")]
        public ActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _userRepository.Update(user);
            _userRepository.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Finds a user by his seatnumber and flight id
        /// </summary>
        [HttpGet]
        [Route("flight/{flightId}/seat/{seatNumber}")]
        public ActionResult<User> GetUserBySeatNumber(string flightId, string seatNumber)
        {
            var user = _userRepository.GetBySeatNumber(flightId, seatNumber);

 

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}

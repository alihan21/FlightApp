using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : Controller
  {
    private readonly IUserRepository _userRepository;
    private readonly IStaffRepository _staffRepository;

    public UserController(IUserRepository userRepository, IStaffRepository staffRepository)
    {
      _userRepository = userRepository;
      _staffRepository = staffRepository;
    }


    // GET: api/Users
    /// <summary>
    /// Get all recipes ordered by name
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
      var users = _userRepository.GetAll().ToList();

      if(users == null || !users.Any())
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

    [HttpGet("staff/loginCode/{loginCode}")]
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
    /// Finds a user by his seatnumber and plane id
    /// </summary>
    [HttpGet]
    [Route("plane/{planeId}/seat/{seatNumber}")]
    public ActionResult GetUserBySeatNumber(int planeId, string seatNumber)
    {
      var user = _userRepository.GetBySeatNumber(seatNumber, planeId);

      if(user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }
  }
}

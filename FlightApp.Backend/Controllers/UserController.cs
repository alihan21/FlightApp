using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FlightApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository context)
        {
                _userRepository = context;
        }


        // GET: api/Users
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
                return _userRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = _userRepository.GetBy(id);
            if (user == null) return NotFound();
            return user;
        }

        /// <summary>
        /// Modifies a user
        /// </summary>
        /// 
        [HttpPut("{id}")]
        public IActionResult PutRecipe(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            _userRepository.Update(user);
            _userRepository.SaveChanges();
            return NoContent();
        }

    }
}
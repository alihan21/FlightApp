using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlightApp.Backend.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class PlaneController : Controller
  {
    private readonly IPlaneRepository _planeRepository;


    public PlaneController(IPlaneRepository context)
    {
      _planeRepository = context;
    }

    [HttpGet]
    public IEnumerable<Plane> GetPlanes()
    {
      return _planeRepository.GetAll();
    }


    [HttpGet("{id}")]
    public ActionResult<Plane> GetPlane(int id)
    {
      Plane plane = _planeRepository.GetBy(id);
      if (plane == null)
      {
        return NotFound();
      }

      return plane;
    }
  }
}

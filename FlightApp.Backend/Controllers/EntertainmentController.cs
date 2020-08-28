using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FlightApp.Backend.Models.Domain;
using FlightApp.Backend.Models.DTO_s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlightApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntertainmentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EntertainmentDTO>> GetMovies()
        {
            var movieDTOs = GetMoviesFromAPI();

            if(movieDTOs == null)
            {
                return NotFound("Movies not found");
            }

            return movieDTOs;
        }

        private List<EntertainmentDTO> GetMoviesFromAPI()
        {
            GenerateEntertainmentItems();
            List<EntertainmentDTO> movieDTOs = new List<EntertainmentDTO>();
            HttpClient client = new HttpClient();

            foreach(string entertainmentItem in EntertainmentItems)
            {
                string getEntertainmentQuery = "http://www.omdbapi.com/?t=" + entertainmentItem + "&apikey=5c7c5f26";
                var response = client.GetStringAsync(getEntertainmentQuery);

                Entertainment movie = JsonConvert.DeserializeObject<Entertainment>(response.Result);

                movieDTOs.Add(new EntertainmentDTO(movie));
            }

            movieDTOs.OrderBy(m => m.Type).ThenBy(m => m.Title);

            return movieDTOs;
        }

        private void GenerateEntertainmentItems()
        {
            EntertainmentItems = new List<string>
            {
                "star+wars",
                "titanic",
                "avengers",
                "hancock",
                "harry+potter",
                "naruto+the+movie",
                "inception",
                "taken",
                "taken+2",
                "the+last",
                "maroon+5",
                "waka",
                "old+town+road",
                "billie+eilish",
                "justin+bieber",
                "XXXTentacion",
                "post+malone",
                "wiz+khalifa",
                "eminem",
                "kendrick+lamar",
                "big+bang+theory",
                "the+100",
                "naruto",
                "the+flash",
                "the+vampire+diaries",
                "the+originals",
                "one+punch+man",
                "hunter+x+hunter",
                "death+note",
                "code+geass",
            };
        }

        private List<string> EntertainmentItems { get; set; }
    }
}
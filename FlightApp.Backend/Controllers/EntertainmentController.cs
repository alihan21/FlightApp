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
            GenerateMovieNames();
            List<EntertainmentDTO> movieDTOs = new List<EntertainmentDTO>();
            HttpClient client = new HttpClient();

            foreach(string movieName in MovieNames)
            {
                string getMovieQuery = "http://www.omdbapi.com/?t=" + movieName + "&apikey=5c7c5f26";
                var response = client.GetStringAsync(getMovieQuery);

                Entertainment movie = JsonConvert.DeserializeObject<Entertainment>(response.Result);

                movieDTOs.Add(new EntertainmentDTO(movie));
            }

            return movieDTOs;
        }

        private void GenerateMovieNames()
        {
            MovieNames = new List<string>
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
                "the+last"
            };
        }

        private List<string> MovieNames { get; set; }
    }
}
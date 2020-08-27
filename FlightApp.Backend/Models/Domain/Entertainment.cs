using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightApp.Backend.Models.Domain
{
    public class Entertainment
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string PG { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        [JsonProperty("imdbVotes")]
        public string ImdbVotes { get; set; }
        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public bool Response { get; set; }

        public Entertainment()
        {

        }
    }
}

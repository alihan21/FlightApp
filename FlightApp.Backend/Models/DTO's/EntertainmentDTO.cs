using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.DTO_s
{
    public class EntertainmentDTO
    {
        public string Title { get; set; }
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
        public string Type { get; set; }

        public EntertainmentDTO(Entertainment entertainment)
        {
            Title = entertainment.Title;
            Released = entertainment.Released;
            Runtime = entertainment.Runtime;
            Genre = entertainment.Genre;
            Director = entertainment.Director;
            Writer = entertainment.Writer;
            Actors = entertainment.Actors;
            Plot = entertainment.Plot;
            Language = entertainment.Language;
            Country = entertainment.Country;
            Awards = entertainment.Awards;
            Poster = entertainment.Poster;
            Type = entertainment.Type;
        }
    }
}

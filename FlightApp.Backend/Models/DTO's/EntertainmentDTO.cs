using FlightApp.Backend.Models.Domain;
using System.Collections.Generic;

namespace FlightApp.Backend.Models.DTO_s
{
    public class EntertainmentDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
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
        public List<RatingDTO> Ratings { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string ImdbId { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public bool Response { get; set; }

        public EntertainmentDTO(Entertainment entertainment)
        {
            Ratings = new List<RatingDTO>();
            Title = entertainment.Title;
            Year = entertainment.Year;
            PG = entertainment.PG;
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
            if(entertainment.Ratings.Count > 0)
            {
                foreach (Rating rating in entertainment.Ratings)
                {
                    Ratings.Add(new RatingDTO(rating));
                }
            }
            Metascore = entertainment.Metascore;
            ImdbRating = entertainment.ImdbRating;
            ImdbVotes = entertainment.ImdbVotes;
            ImdbId = entertainment.ImdbId;
            Type = entertainment.Type;
            DVD = entertainment.DVD;
            BoxOffice = entertainment.BoxOffice;
            Production = entertainment.Production;
            Website = entertainment.Website;
            Response = entertainment.Response;
        }

        public class RatingDTO
        {
            public string Source { get; set; }
            public string Value { get; set; }

            public RatingDTO(Rating rating)
            {
                Source = rating.Source;
                Value = rating.Value;
            }
        }
    }
}

using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace FlightApp.Frontend.ViewModels
{
    public class MoviesViewModel : BindableBase
    {
        public ObservableCollection<EntertainmentViewModel> Movies { get; set; }

        public MoviesViewModel()
        {
            Movies = new ObservableCollection<EntertainmentViewModel>();
            GetMoviesFromAPI();
        }

        private async void GetMoviesFromAPI()
        {
            HttpClient client = new HttpClient();

            var res = await client.GetStringAsync("http://localhost:60177/api/Entertainment");

            var movies = JsonConvert.DeserializeObject<List<Entertainment>>(res);

            if (movies != null)
            {
                foreach (Entertainment movie in movies)
                {
                    Movies.Add(new EntertainmentViewModel(movie));
                }
            }
        }
    }
}

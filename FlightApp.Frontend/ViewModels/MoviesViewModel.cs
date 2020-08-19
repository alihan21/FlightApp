﻿using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.ViewModels
{
    public class MoviesViewModel
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

            if(movies != null)
            {
                foreach (Entertainment movie in movies)
                {
                    Movies.Add(new EntertainmentViewModel(movie));
                }
            }
        }
    }
}

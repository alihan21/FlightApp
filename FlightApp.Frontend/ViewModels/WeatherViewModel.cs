﻿using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using FlightApp.Frontend.Models.Weather;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace FlightApp.Frontend.ViewModels
{
    public class WeatherViewModel : BindableBase
    {

        public ObservableCollection<Root> MyWeather { get; set; }
        public string Icon { get; set; }


        public WeatherViewModel()
        {
            MyWeather = new ObservableCollection<Root>();
            Icon = "";
        }

        public async Task LoadDataAsync(int passengerId)
        {
            HttpClient client = new HttpClient();
            var flightJson = await client.GetStringAsync(new Uri($"http://localhost:60177/api/UserFlight/user/{passengerId}"));
            var currentUserFlight = JsonConvert.DeserializeObject<UserFlight>(flightJson);
            var city = currentUserFlight.Flight.Destination;
            var weatherJson = await client.GetStringAsync(new Uri($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=cd5d6a75dee7aa930f7fbf96a061a555"));
            var myWeathers = JsonConvert.DeserializeObject<Root>(weatherJson);
            Icon = myWeathers.Weather[0].Icon;
            MyWeather.Add(myWeathers);
        }
    }
}

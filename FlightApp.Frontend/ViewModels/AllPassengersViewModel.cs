using FlightApp.Frontend.Models;
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
    public class AllPassengersViewModel
    {
        public ObservableCollection<PassengerViewModel> Passengers { get; set; }

        public PassengerViewModel SelectedPassenger { get; set; }

        public AllPassengersViewModel(string flightId)
        {
            Passengers = new ObservableCollection<PassengerViewModel>();
            GetPassengersCurrentFlight(flightId);
        }

        private async void GetPassengersCurrentFlight(string flightId)
        {
            HttpClient httpClient = new HttpClient();

            var res = await httpClient.GetStringAsync($"http://localhost:60177/api/User/flights/{flightId}/passengers/all");

            var passengers = JsonConvert.DeserializeObject<List<Passenger>>(res);

            foreach(Passenger passenger in passengers)
            {
                Passengers.Add(new PassengerViewModel(passenger));
            }
        }
    }
}

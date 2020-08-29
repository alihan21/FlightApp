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
    public class SeatViewModel
    {
        public ObservableCollection<Seat> Seats { get; }

        public Seat SelectedSeat { get; set; }

        public SeatViewModel(string flightId)
        {
            Seats = new ObservableCollection<Seat>();
            LoadDataAsync(flightId);
        }

        public SeatViewModel()
        {

        }

        public async void MovePassenger(string flightId, string oldSeatNumber)
        {
            if(SelectedSeat != null)
            {
                HttpClient client = new HttpClient();
                var json = await client.PostAsync(new Uri($"http://localhost:60177/api/Seat/flight/{flightId}/seats/change/{oldSeatNumber}/{SelectedSeat.SeatNumber}"), null);
            }
        }

        private async void LoadDataAsync(string flightId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Seat/flight/{flightId}/availableSeats"));
            var seatList = JsonConvert.DeserializeObject<IList<Seat>>(json);

            foreach (var seat in seatList)
            {
                Seats.Add(seat);
            }
        }
    }
}

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

        public SeatViewModel()
        {
            Seats = new ObservableCollection<Seat>();
            loadDataAsync();
        }

        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://http://localhost:62382/api/seats/plane/{planeId}"));
            var seatList = JsonConvert.DeserializeObject<IList<Seat>>(json);
            foreach (var seat in seatList)
            {
                Seats.Add(seat);
            }
        }

    }
}

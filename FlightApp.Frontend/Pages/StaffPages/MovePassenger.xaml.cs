using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where a staff member can move a passenger to another seat
    /// </summary>
    public sealed partial class MovePassenger : Page
    {
        public MovePassenger()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:62382/api/Seat/plane/1"));
            var seatList = JsonConvert.DeserializeObject<ObservableCollection<Seat>>(json);
            lv.ItemsSource = seatList;
        }
    }
}

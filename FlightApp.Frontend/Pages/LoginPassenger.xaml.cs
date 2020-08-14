using FlightApp.Frontend.Models;
using FlightApp.Frontend.Pages.PassengerPages;
using FlightApp.Frontend.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// Login page for a passenger
    /// </summary>
    public sealed partial class LoginPassenger : Page
    {
        public LoginPassenger()
        {
            this.InitializeComponent();
        }

        private void navigateToStaffmemberPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginStaff));
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            string seatNumber = tbPassword.Text.Trim();
            string flightId = tbFlightId.Text.Trim();

            if (!string.IsNullOrEmpty(seatNumber) && !string.IsNullOrEmpty(flightId))
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/User/flight/{flightId}/seat/{seatNumber}"));
                var loggedInPassenger = JsonConvert.DeserializeObject<Passenger>(json);

                PassengerViewModel passengerViewModel = new PassengerViewModel(loggedInPassenger, flightId, seatNumber);

                if (loggedInPassenger != null)
                {
                    Frame.Navigate(typeof(MainPagePassenger), passengerViewModel);
                }
            }
        }
    }
}

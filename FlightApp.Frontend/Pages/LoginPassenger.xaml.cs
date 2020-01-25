using FlightApp.Frontend.Models;
using FlightApp.Frontend.Pages.PassengerPages;
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
            string password = tbPassword.Text;
            string flightId = tbFlightId.Text;

            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(flightId))
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri($"http://localhost:57435/api/User/flight/{flightId}/seat/{password}"));
                var loggedInPassenger = JsonConvert.DeserializeObject<Passenger>(json);

                if (loggedInPassenger != null)
                {
                    Frame.Navigate(typeof(MainPagePassenger), loggedInPassenger);
                }
            }
        }
    }
}

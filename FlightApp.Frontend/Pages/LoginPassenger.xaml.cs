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
            LoginStoryboard.Begin();
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

                try
                {
                    var json = await client.GetAsync(new Uri($"http://localhost:60177/api/User/flight/{flightId}/seat/{seatNumber}"));

                    if (json.IsSuccessStatusCode)
                    {
                        var loggedInPassenger = JsonConvert.DeserializeObject<Passenger>(json.Content.ReadAsStringAsync().Result);

                        PassengerViewModel passengerViewModel = new PassengerViewModel(loggedInPassenger, flightId, seatNumber);

                        if (loggedInPassenger != null)
                        {
                            Frame.Navigate(typeof(MainPagePassenger), passengerViewModel);
                        }

                    }
                    else
                    {
                        ContentDialog myNotification = new ContentDialog
                        {
                            Title = "Warning",
                            Content = "Username or password is incorrect. Please fill in a valid login",
                            CloseButtonText = "Okay"

                        };

                        ContentDialogResult result = await myNotification.ShowAsync();

                    }

                }
                finally
                {
                    client.Dispose();
                }


            }
        }
    }
}
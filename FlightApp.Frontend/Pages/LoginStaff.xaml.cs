using FlightApp.Frontend.Models;
using FlightApp.Frontend.Pages.StaffPages;
using FlightApp.Frontend.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// Login page for a staff
    /// </summary>
    public sealed partial class LoginStaff : Page
    {
        public LoginStaff()
        {
            this.InitializeComponent();
        }

        private void NavigateToPassengerPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPassenger));
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            string password = tbPassword.Text;

            try
            {
                int loginCode = Int16.Parse(password);

                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/User/staff/login/{loginCode}"));
                var loggedInStaff = JsonConvert.DeserializeObject<Staff>(json);

                if (loggedInStaff != null)
                {
                    StaffViewModel staffViewModel = new StaffViewModel(loggedInStaff)
                    {
                        FlightId = tbFlightId.Text
                    };

                    Frame.Navigate(typeof(MainPageStaff), staffViewModel);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

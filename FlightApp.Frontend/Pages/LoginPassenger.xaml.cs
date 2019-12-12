using FlightApp.Frontend.Pages.PassengerPages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System.Net.Http;

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

      if (!string.IsNullOrEmpty(password))
      {
        HttpClient client = new HttpClient();
        var json = await client.GetStringAsync(new Uri($"http://localhost:49926/api/User/plane/7/seat/{password}"));
        var loggedInPassenger = JsonConvert.DeserializeObject<Passenger>(json);

        if (loggedInPassenger != null)
        {
          Frame.Navigate(typeof(MainPagePassenger), loggedInPassenger);
        }
      }
    }
  }
}

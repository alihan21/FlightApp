using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
  /// <summary>
  /// Page where a passenger can check information about current flight
  /// </summary>
  public sealed partial class FlightInfo : Page
  {
    public FlightInfo()
    {
      this.InitializeComponent();
    }

    protected override async void OnNavigatedTo(NavigationEventArgs e) {
      base.OnNavigatedTo(e);
      HttpClient client = new HttpClient();
      var json = await client.GetStringAsync(new Uri("http://localhost:56013/api/Flight"));
      var lst = JsonConvert.DeserializeObject<ObservableCollection<Flight>>(json);
      lv.ItemsSource = lst; }

  }
}

using FlightApp.Frontend.Models;
using FlightApp.Frontend.Models.Weather;
using FlightApp.Frontend.ViewModels;
using System;
using System.Drawing;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Weather : Page
    {

        public WeatherViewModel WeatherViewModel { get; set; }

        public Weather()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            WeatherViewModel = new WeatherViewModel();
            Initiliaze((int)e.Parameter);
            ShowPOI();
        }

        private async void Initiliaze(int passengerId)
        {

            await WeatherViewModel.LoadDataAsync(passengerId);
            myWeatherInfo.ItemsSource = WeatherViewModel.MyWeather;
            string icon = WeatherViewModel.Icon;
            myWeatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/wn/{icon}.png", UriKind.Absolute));
        }


        private async void ShowPOI()
        {
            var position = await LocationManager.GetPosition();
            BasicGeoposition snPosition = new BasicGeoposition() { Latitude = position.Coordinate.Latitude, Longitude = position.Coordinate.Longitude };
            Geopoint snPoint = new Geopoint(snPosition);
            MapIcon mapIcon1 = new MapIcon();
            mapIcon1.Location = snPoint;
            mapIcon1.Title = "Current location";
            mapIcon1.ZIndex = 0;

            MapControl1.MapElements.Add(mapIcon1);
            MapControl1.MapServiceToken = "xjPt4JIRIYcbojxbehKX~AFzzIRdosDJXeC5jh5OmSQ~AmtD5GNB_d-DgWlDAyP0G53hphDQN-ggPgyCTFdMdACZVWA5oY67HZSxsxePna3s";

        }
    }
}

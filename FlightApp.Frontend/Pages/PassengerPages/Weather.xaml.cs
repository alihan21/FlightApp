using FlightApp.Frontend.ViewModels;
using System;
using Windows.UI.Xaml.Controls;
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
            initiliaze((int)e.Parameter);
        }

        private async void initiliaze(int passengerId)
        {
            await WeatherViewModel.loadDataAsync(passengerId);
            myWeatherInfo.ItemsSource = WeatherViewModel.myWeather;
            string icon = WeatherViewModel.icon;
            myWeatherIcon.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/wn/{icon}.png", UriKind.Absolute));
        }
    }
}

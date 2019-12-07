using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Main page for a passenger
    /// </summary>
    public sealed partial class MainPagePassenger : Page
    {
        public MainPagePassenger()
        {
            this.InitializeComponent();
        }

        private void NavigateToFlightInfo(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(FlightInfo));
        }

        private void NavigateToOrderFood(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(OrderFood));
        }

        private void NavigateToOrderHistory(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(OrderHistory));
        }

        private void NavigateToEntertainment(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(Entertainment));
        }

        private void NavigateToWeather(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(Weather));
        }

        private void NavigateToChat(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(Chat));
        }

        private void NavigateToPage(Type type)
        {
            Frame.Navigate(type);
        }
    }
}

using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Main page for a passenger
    /// </summary>
    public sealed partial class MainPagePassenger : Page
    {
        public PassengerViewModel LoggedPassenger { get; set; }

        public MainPagePassenger()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoggedPassenger = (PassengerViewModel)e.Parameter;
            tbPassengerName.DataContext = LoggedPassenger;

            if (LoggedPassenger.ChannelId == 0)
            {
                btnNavigateToChat.Visibility = Visibility.Collapsed;
            }
        }

        private void NavigateToFlightInfo(object sender, RoutedEventArgs e)
        {
            if (LoggedPassenger != null)
            {
                Frame.Navigate(typeof(FlightInfo), LoggedPassenger.Id);
            }
        }

        private void NavigateToOrderFood(object sender, RoutedEventArgs e)
        {
            if(LoggedPassenger != null)
            {
                Frame.Navigate(typeof(OrderFood), LoggedPassenger);
            }
        }

        private void NavigateToOrderHistory(object sender, RoutedEventArgs e)
        {
            if (LoggedPassenger != null)
            {
                Frame.Navigate(typeof(OrderHistory), LoggedPassenger);
            }
        }

        private void NavigateToEntertainment(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(Entertainment));
        }

        private void NavigateToWeather(object sender, RoutedEventArgs e)
        {
            if (LoggedPassenger != null)
            {
                Frame.Navigate(typeof(Weather), LoggedPassenger.Id);
            }
        }

        private void NavigateToChat(object sender, RoutedEventArgs e)
        {
            if (LoggedPassenger != null)
            {
                Frame.Navigate(typeof(Chat), LoggedPassenger);
            }
        }

        private void NavigateToPage(Type type)
        {
            Frame.Navigate(type);
        }
    }
}

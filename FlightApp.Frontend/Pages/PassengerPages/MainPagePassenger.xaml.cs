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
        public Passenger CurrentPassenger { get; set; }


        public MainPagePassenger()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CurrentPassenger = ((Passenger)e.Parameter);
            if (CurrentPassenger.ChannelId == 0)
            {
                btnNavigateToChat.Visibility = Visibility.Collapsed;
            }
            LoggedPassenger = (PassengerViewModel)e.Parameter;
            tbPassengerName.DataContext = LoggedPassenger;
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
                Frame.Navigate(typeof(OrderHistory), LoggedPassenger.Id);
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
                Frame.Navigate(typeof(Chat), CurrentPassenger);
            }
        }

        private void NavigateToPage(Type type)
        {
            Frame.Navigate(type);
        }
    }
}

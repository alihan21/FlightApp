using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
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
        public NotificationViewModel NotificationViewModel { get; set; }

        public MainPagePassenger()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            LoggedPassenger = (PassengerViewModel)e.Parameter;
            tbPassengerName.DataContext = LoggedPassenger;

            if (LoggedPassenger.ChannelId == 0)
            {
                btnNavigateToChat.Visibility = Visibility.Collapsed;
            }

            NotificationViewModel = new NotificationViewModel();
            await GetNotification();
            if (!NotificationViewModel.isNotificationRead)
            {
                if (NotificationViewModel.Notification.Type == "CustomNotification")
                {
                    ContentDialog myNotification = new ContentDialog
                    {
                        Title = NotificationViewModel.Notification.Type,
                        Content = NotificationViewModel.Notification.Text,
                        PrimaryButtonText = "Confirm",
                        CloseButtonText = "Cancel"

                    };

                    ContentDialogResult result = await myNotification.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        NotificationViewModel.NotificationIsRead(LoggedPassenger.Id);
                    }
                }
                else
                {
                    ContentDialog myNotification = new ContentDialog
                    {
                        Title = NotificationViewModel.Notification.Type,
                        Content = NotificationViewModel.Notification.Text,
                        PrimaryButtonText = "Go To Shop",
                        SecondaryButtonText = "Not Interested",
                        CloseButtonText = "Cancel"

                    };

                    ContentDialogResult result = await myNotification.ShowAsync();

                    if (result == ContentDialogResult.Primary)
                    {
                        NotificationViewModel.NotificationIsRead(LoggedPassenger.Id);
                        Frame.Navigate(typeof(OrderFood), LoggedPassenger);
                    }
                    else if(result == ContentDialogResult.Secondary)
                    {
                        NotificationViewModel.NotificationIsRead(LoggedPassenger.Id);
                    }
                }
            }
        }

        private async Task GetNotification()
        {
            await NotificationViewModel.GetNotification(LoggedPassenger.Id);
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
            if (LoggedPassenger != null)
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
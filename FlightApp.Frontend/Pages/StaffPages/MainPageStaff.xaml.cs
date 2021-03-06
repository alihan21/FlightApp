using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Main page for a staff member
    /// </summary>
    public sealed partial class MainPageStaff : Page
    {
        public StaffViewModel LoggedStaff { get; set; }

        public MainPageStaff()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
            tbStaffName.DataContext = LoggedStaff;
        }

        private void NavigateToMovePassenger(object sender, RoutedEventArgs e)
        {
            if (LoggedStaff != null)
            {
                Frame.Navigate(typeof(MovePassenger), LoggedStaff);
            }
        }

        private void NavigateToOrderOverview(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrderOverview));
        }

        private void NavigateToNotification(object sender, RoutedEventArgs e)
        {
            if (LoggedStaff != null)
            {
                Frame.Navigate(typeof(Notification), LoggedStaff);
            }
        }
    }
}

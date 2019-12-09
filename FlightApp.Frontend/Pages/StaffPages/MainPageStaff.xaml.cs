using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Main page for a staff member
    /// </summary>
    public sealed partial class MainPageStaff : Page
    {
        public MainPageStaff()
        {
            this.InitializeComponent();
        }

        private void NavigateToMovePassenger(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(MovePassenger));
        }

        private void NavigateToOrderOverview(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(OrderOverview));
        }

        private void NavigateToCustomNotification(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(CustomNotification));
        }

        private void NavigateToAdvertise(object sender, RoutedEventArgs e)
        {
            NavigateToPage(typeof(MovePassenger));
        }

        private void NavigateToPage(Type type)
        {
            Frame.Navigate(type);
        }
    }
}

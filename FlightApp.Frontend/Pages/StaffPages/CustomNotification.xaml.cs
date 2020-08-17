using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where a staff member can send a notification (message) to a specific or all passengers
    /// </summary>
    public sealed partial class CustomNotification : Page
    {
        public StaffViewModel LoggedStaff { get; set; }

        public CustomNotification()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
        }

        private void SendNotification(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NotificationViewModel notificationViewModel = new NotificationViewModel()
            {
                Text = tbCustomNotification.Text,
                Type = "CustomNotification"
            };

            notificationViewModel.AddNotificationAsync(LoggedStaff.FlightId);
            tbCustomNotification.Text = "";
        }
    }
}

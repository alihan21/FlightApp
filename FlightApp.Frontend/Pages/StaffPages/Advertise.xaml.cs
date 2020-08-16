using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where a staff member can advertise (such as promotions and exclusives, and so on...)
    /// </summary>
    public sealed partial class Advertise : Page
    {
        public StaffViewModel LoggedStaff { get; private set; }

        public Advertise()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
        }

        private void BeginAdvertise(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NotificationViewModel notificationViewModel = new NotificationViewModel()
            {
                Text = tbMessage.Text,
                Type = "Advertisement"
            };

            notificationViewModel.AddNotificationAsync(LoggedStaff.FlightId);
        }
    }
}

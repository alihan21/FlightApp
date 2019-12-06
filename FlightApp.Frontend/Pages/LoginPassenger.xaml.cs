using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// Login page for a passenger
    /// </summary>
    public sealed partial class LoginPassenger : Page
    {
        public LoginPassenger()
        {
            this.InitializeComponent();
        }

        private void navigateToStaffmemberPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginStaff));
        }
    }
}

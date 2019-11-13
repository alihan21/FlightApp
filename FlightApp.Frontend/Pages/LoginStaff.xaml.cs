using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// Login page for a staff
    /// </summary>
    public sealed partial class LoginStaff : Page
    {
        public LoginStaff()
        {
            this.InitializeComponent();
        }

        private void NavigateToPassengerPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPassenger));
        }
    }
}

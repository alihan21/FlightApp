using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// This is where a staffmember can login
    /// </summary>
    public sealed partial class LoginStaff : Page
    {
        public LoginStaff()
        {
            InitializeComponent();
        }

        private void NavigateToPassengerPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPassenger));
        }
    }
}

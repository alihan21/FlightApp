using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlightApp.Frontend.Pages
{
    /// <summary>
    /// This is the page login page for passenger
    /// </summary>
    public sealed partial class LoginPassenger : Page
    {
        public LoginPassenger()
        {
            InitializeComponent();
        }

        private void navigateToStaffmemberPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginStaff));
        }
    }
}

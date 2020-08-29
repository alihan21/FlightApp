using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Notification : Page
    {
        public AllPassengersViewModel AllPassengersViewModel { get; set; }
        public StaffViewModel LoggedStaff { get; private set; }


        public Notification()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
            AllPassengersViewModel = new AllPassengersViewModel(LoggedStaff.FlightId);
        }

        private void BeginAdvertise(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (tbMessage.Text.Length > 0)
            {
                ComboBoxItem selectedNotificationType = (ComboBoxItem)cbNotificationType.SelectedItem;

                NotificationViewModel notificationViewModel = new NotificationViewModel()
                {
                    Text = tbMessage.Text,
                    Type = (string)selectedNotificationType.Content
                    
                };

                if (cbIsAllPassengersSelected.IsChecked == true)
                {
                    if (LoggedStaff != null)
                    {
                        notificationViewModel.AddNotificationAsync(LoggedStaff.FlightId);
                    }
                }
                else
                {
                    if (AllPassengersViewModel.SelectedPassenger != null)
                    {
                        notificationViewModel.AddNotificationToPassengerAsync(AllPassengersViewModel.SelectedPassenger.Id);
                    }
                }

                tbMessage.Text = "";
                cbPassengers.SelectedIndex = -1;
                cbIsAllPassengersSelected.IsChecked = false;
            }
        }

        private void SelectPassenger(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            PassengerViewModel passenger = (PassengerViewModel)comboBox.SelectedItem;

            if (passenger != null)
            {
                AllPassengersViewModel.SelectedPassenger = passenger;
            }
        }
    }
}

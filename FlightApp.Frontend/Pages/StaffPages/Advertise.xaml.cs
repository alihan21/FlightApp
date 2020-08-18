using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where a staff member can advertise (such as promotions and exclusives, and so on...)
    /// </summary>
    public sealed partial class Advertise : Page
    {
        public AllPassengersViewModel AllPassengersViewModel { get; set; }
        public StaffViewModel LoggedStaff { get; private set; }

        public Advertise()
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
            NotificationViewModel notificationViewModel = new NotificationViewModel()
            {
                Text = tbMessage.Text,
                Type = "Advertisement"
            };

            if (cbIsAllPassengersSelected.IsChecked == true)
            {
                if(LoggedStaff != null)
                {
                    notificationViewModel.AddNotificationAsync(LoggedStaff.FlightId);
                }
            }
            else
            {
                if(AllPassengersViewModel.SelectedPassenger != null)
                {
                    notificationViewModel.AddNotificianToPassengerAsync(AllPassengersViewModel.SelectedPassenger.Id);
                }
            }
            
            tbMessage.Text = "";
            cbPassengers.SelectedIndex = -1;
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

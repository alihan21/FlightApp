using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where a staff member can move a passenger to another seat
    /// </summary>
    public sealed partial class MovePassenger : Page
    {
        public StaffViewModel LoggedStaff { get; set; }

        public SeatViewModel SeatViewModel { get; set; }

        public MovePassenger()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
            SeatViewModel = new SeatViewModel(LoggedStaff.FlightId);
        }

        private void ChangePassengerSeat(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            SeatViewModel.MovePassenger(LoggedStaff.FlightId, tbOldSeatNumber.Text);
            tbOldSeatNumber.Text = "";
            cbSeats.SelectedIndex = -1;
        }

        private void SelectSeat(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Seat seat = (Seat)comboBox.SelectedItem;

            if(seat != null)
            {
                SeatViewModel.SelectedSeat = seat;
            }
        }
    }
}

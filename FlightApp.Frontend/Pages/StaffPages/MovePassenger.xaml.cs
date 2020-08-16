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
        public SeatViewModel SeatViewModel { get; set; }

        public MovePassenger()
        {
            SeatViewModel = new SeatViewModel();
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

        }
    }
}

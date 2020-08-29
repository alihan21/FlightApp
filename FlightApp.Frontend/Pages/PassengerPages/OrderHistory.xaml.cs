using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where a passenger can see his history of orders
    /// </summary>
    public sealed partial class OrderHistory : Page
    {
        public PassengerViewModel PassengerViewModel { get; set; }
        public OrderFoodViewModel OrderFoodViewModel { get; set; }

        public OrderHistory()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            PassengerViewModel = (PassengerViewModel)e.Parameter;
            OrderFoodViewModel = new OrderFoodViewModel();
            OrderFoodViewModel.LoadOrderHistoryAsync(PassengerViewModel.Id);
            LayoutRoot.DataContext = new CollectionViewSource { Source = OrderFoodViewModel.OrderHistory };
        }
    }
}

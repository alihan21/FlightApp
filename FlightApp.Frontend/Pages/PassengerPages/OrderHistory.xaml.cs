using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where a passenger can see his history of orders
    /// </summary>
    public sealed partial class OrderHistory : Page
    {
        public OrderFoodViewModel OrderFoodViewModels { get; set; }

        public OrderHistory()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            OrderFoodViewModels = new OrderFoodViewModel();
            //OrderFoodViewModels.loadOrderHistoryAsync((int)e.Parameter);
            MyFoodHistory.ItemsSource = OrderFoodViewModels.OrderHistory;
        }
    }
}

using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where the staff can see the orders made by passengers
    /// </summary>
    public sealed partial class OrderOverview : Page
    {
        public AllOrdersViewModel AllOrdersViewModel { get; set; }

        public OrderOverview()
        {
            AllOrdersViewModel = new AllOrdersViewModel();
            this.InitializeComponent();
            LayoutRoot.DataContext = new CollectionViewSource { Source = AllOrdersViewModel.OrdersViewModel };
        }

        private void CompleteOrder(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            OrderViewModel orderViewModel = (OrderViewModel)lbOrders.SelectedItem;

            if(orderViewModel != null)
            {
                AllOrdersViewModel.CompleteOrder(orderViewModel);
            }
        }
    }
}

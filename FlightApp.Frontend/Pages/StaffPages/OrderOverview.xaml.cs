using FlightApp.Frontend.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.StaffPages
{
    /// <summary>
    /// Page where the staff can see the orders made by passengers
    /// </summary>
    public sealed partial class OrderOverview : Page
    {
        public AllOrdersViewModel AllOrdersViewModel { get; set; }

        public StaffViewModel LoggedStaff { get; set; }

        public OrderOverview()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            LoggedStaff = (StaffViewModel)e.Parameter;
            AllOrdersViewModel = new AllOrdersViewModel(LoggedStaff.FlightId);
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

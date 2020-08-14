using FlightApp.Frontend.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where a passenger can see his history of orders
    /// </summary>
    public sealed partial class OrderHistory : Page
    {
        ObservableCollection<OrderFoodViewModel> OrderHistoryCollection { get; set; }

        public OrderHistory()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            int passengerId = 0;

            if (e.Parameter != null)
            {
                passengerId = (int)e.Parameter;

                HttpClient client = new HttpClient();
                try
                {
                    var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/OrderFood/user/{passengerId}"));

                    var orderHistoryOfPassenger = JsonConvert.DeserializeObject<ObservableCollection<OrderFoodViewModel>>(json);

                    if (orderHistoryOfPassenger != null)
                    {
                        OrderHistoryCollection = orderHistoryOfPassenger;
                        lbOrderHistory.DataContext = OrderHistoryCollection;
                        lbTest.DataContext = OrderHistoryCollection;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}

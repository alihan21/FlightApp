using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlightApp.Frontend.ViewModels
{
    public class AllOrdersViewModel
    {
        public ObservableCollection<OrderViewModel> OrdersViewModel { get; set; }

        public AllOrdersViewModel()
        {
            OrdersViewModel = new ObservableCollection<OrderViewModel>();
            GetAllOrders();
        }

        private async void GetAllOrders()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("http://localhost:60177/api/Order"));
            var allOrders = JsonConvert.DeserializeObject<List<Order>>(json);

            foreach(Order order in allOrders)
            {
                OrderViewModel orderViewModel = new OrderViewModel(order);
                OrdersViewModel.Add(orderViewModel);
            }
        }

        // This method is used by the Staff. When this method is called this means the food
        // of a passenger is served
        public async void CompleteOrder(OrderViewModel orderViewModel)
        {
            HttpClient httpClient = new HttpClient();

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Order/flightId/passengerSeat/orders/{orderViewModel.OrderId}/completeOrder", null);

            if (res.IsSuccessStatusCode)
            {
                OrdersViewModel.Remove(orderViewModel);
            }
        }
    }
}

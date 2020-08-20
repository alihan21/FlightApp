using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace FlightApp.Frontend.ViewModels
{
    public class OrderFoodViewModel : BindableBase
    {
        public ObservableCollection<Food> Foods { get; set; }
        public ObservableCollection<OrderViewModel> OrderHistory { get; set; }

        public Order CurrentOrder { get; set; }

        public OrderFoodViewModel()
        {
            Foods = new ObservableCollection<Food>();
            OrderHistory = new ObservableCollection<OrderViewModel>();
            CurrentOrder = new Order();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Food"));
            var foodList = JsonConvert.DeserializeObject<IList<Food>>(json);
            foreach (var food in foodList)
            {
                Foods.Add(food);
            }
        }

        public async void LoadOrderHistoryAsync(int passengerId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Order/passengers/{passengerId}/orderHistory"));

            var orders = JsonConvert.DeserializeObject<List<Order>>(json);
            foreach (Order order in orders)
            {
                OrderViewModel orderViewModel = new OrderViewModel(order);
                OrderHistory.Add(orderViewModel);
            }
        }
    }
}

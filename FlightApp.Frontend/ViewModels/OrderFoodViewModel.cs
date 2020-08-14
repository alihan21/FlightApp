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
        public ObservableCollection<OrderFood> OrderHistory { get; set; }


        public Order CurrentOrder { get; set; }

        public ObservableCollection<Food> ShoppingCart { get; set; }


        public OrderFoodViewModel()
        {
            Foods = new ObservableCollection<Food>();
            OrderHistory = new ObservableCollection<OrderFood>();
            CurrentOrder = new Order();
            ShoppingCart = new ObservableCollection<Food>();
            loadDataAsync();
        }

        private async void loadDataAsync()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/Food"));
            var foodList = JsonConvert.DeserializeObject<IList<Food>>(json);
            foreach (var food in foodList)
            {
                Foods.Add(food);
            }
        }

        /*public async void loadOrderHistoryAsync(int passengerId)
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri($"http://localhost:60177/api/OrderFood/user/{passengerId}"));
            var orderFoodList = JsonConvert.DeserializeObject<IList<OrderFood>>(json);
            foreach (var orderFood in orderFoodList)
            {
                OrderHistory.Add(orderFood);
            }
        }

        public async Task AddPassengerOrderAsync(int passengerId)
        {
            // TODO: Find another serializer for Order object
            var currentOrder = JsonConvert.SerializeObject(CurrentOrder.Orders);

            HttpClient client = new HttpClient();
            var res = await client.PostAsync(new Uri($"http://localhost:60177/api/OrderFood/passenger/{passengerId}/Order/"), new HttpStringContent(currentOrder, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));

        }*/
    }
}

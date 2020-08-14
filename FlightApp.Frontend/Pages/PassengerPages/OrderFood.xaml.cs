using FlightApp.Frontend.Models;
using FlightApp.Frontend.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace FlightApp.Frontend.Pages.PassengerPages
{
    /// <summary>
    /// Page where a passenger can order his food
    /// </summary>
    public sealed partial class OrderFood : Page
    {
        public OrderViewModel OrderViewModel { get; set; }

        public FoodViewModel FoodViewModel { get; set; }

        public PassengerViewModel PassengerViewModel { get; set; }

        public OrderFood()
        {
            OrderViewModel = new OrderViewModel();
            FoodViewModel = new FoodViewModel();

            this.InitializeComponent();
            DataContext = OrderViewModel;
            tbTotal.DataContext = OrderViewModel;
        }

        private void AddToOrder(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Button test = (Button)e.OriginalSource;
            Food selectedFood = (Food)test.DataContext;

            if (selectedFood != null)
            {
                OrderLineViewModel existingOrderLine = GetExistingOrderLineByFoodId(selectedFood);

                if (existingOrderLine == null)
                {
                    OrderLineViewModel newOrderLine = new OrderLineViewModel();
                    newOrderLine.Food = selectedFood;
                    newOrderLine.Quantity = 1;
                    OrderViewModel.OrderLines.Add(newOrderLine);
                }
                else
                {
                    existingOrderLine.Quantity++;
                }

                OrderViewModel.Total += Math.Round(selectedFood.Price, 1);
            }
        }

        private void RemoveFromOrder(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Button test = (Button)e.OriginalSource;
            Food selectedFood = (Food)test.DataContext;

            OrderLineViewModel existingOrderLine = GetExistingOrderLineByFoodId(selectedFood);

            if (existingOrderLine != null)
            {
                OrderViewModel.Total -= Math.Round(selectedFood.Price, 1);
                existingOrderLine.Quantity--;

                if (existingOrderLine.Quantity <= 0)
                {
                    OrderViewModel.OrderLines.Remove(existingOrderLine);
                }
            }
        }

        private OrderLineViewModel GetExistingOrderLineByFoodId(Food food)
        {
            return OrderViewModel.OrderLines.SingleOrDefault(ol => ol.Food == food);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                PassengerViewModel = (PassengerViewModel)e.Parameter;
            }
        }

        private void FinalizeOrder(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (PassengerViewModel.FlightId.Length > 0 && PassengerViewModel.SeatNumber.Length > 0)
            {
                FinalizeOrder(PassengerViewModel.FlightId, PassengerViewModel.SeatNumber);
                OrderViewModel.Total = Math.Round(0m, 1);
            }
        }

        private async void FinalizeOrder(string flightId, string seatNumber)
        {
            HttpClient httpClient = new HttpClient();

            var orderLinesJson = JsonConvert.SerializeObject(OrderViewModel.OrderLines);

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Order/{flightId}/{seatNumber}/placeOrder", new StringContent(orderLinesJson,
                System.Text.Encoding.UTF8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                OrderViewModel.OrderLines.Clear();
            }
        }
    }
}

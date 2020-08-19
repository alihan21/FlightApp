using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace FlightApp.Frontend.ViewModels
{
    public class OrderViewModel : BindableBase
    {
        public ObservableCollection<OrderLineViewModel> OrderLines { get; set; } = new ObservableCollection<OrderLineViewModel>();

        public Passenger Passenger { get; set; }

        private decimal _total;

        public decimal Total {
            get { return _total; }
            set {
                if (value != _total)
                {
                    _total = value;
                    RaisePropertyChanged();
                }
            }
        }

        private string _orderLinesString;

        public string OrderLinesString {
            get { return _orderLinesString; }
            set {
                if (value != _orderLinesString)
                {
                    _orderLinesString = value;
                    RaisePropertyChanged();
                }
            }
        }

        public OrderViewModel(Order order)
        {
            Passenger = order.Passenger;
            foreach (OrderLine orderLine in order.OrderLines)
            {
                OrderLineViewModel orderLineViewModel = new OrderLineViewModel(orderLine);
                OrderLines.Add(orderLineViewModel);
                Total += orderLineViewModel.Subtotal;
            }

            ConvertOrderLinesToString();
        }

        public void ConvertOrderLinesToString()
        {
            foreach (OrderLineViewModel orderLineViewModel in OrderLines)
            {
                OrderLinesString += orderLineViewModel.ToString();
            }
        }

        public OrderViewModel()
        {

        }

        public async void FinalizeOrder(string flightId, string seatNumber)
        {
            HttpClient httpClient = new HttpClient();

            var orderLinesJson = JsonConvert.SerializeObject(OrderLines);

            var res = await httpClient.PostAsync($"http://localhost:60177/api/Order/{flightId}/{seatNumber}/placeOrder", new StringContent(orderLinesJson,
                System.Text.Encoding.UTF8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                OrderLines.Clear();
            }
        }
    }
}

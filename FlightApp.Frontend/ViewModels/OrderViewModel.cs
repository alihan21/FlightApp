using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;
using System.Collections.ObjectModel;

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
    }
}

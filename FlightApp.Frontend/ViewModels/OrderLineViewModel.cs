using FlightApp.Frontend.Common;
using FlightApp.Frontend.Models;

namespace FlightApp.Frontend.ViewModels
{
    public class OrderLineViewModel : BindableBase
    {
        private Food _food;

        public Food Food {
            get { return _food; }
            set {
                if (value != _food)
                {
                    _food = value;
                    RaisePropertyChanged();
                }
            }
        }

        private int _quantity;

        public int Quantity {
            get { return _quantity; }
            set {
                if (value != _quantity)
                {
                    _quantity = value;
                    Subtotal = _food.Price * _quantity;
                    RaisePropertyChanged();
                }
            }
        }

        private decimal _subtotal;

        public decimal Subtotal {
            get { return _subtotal; }
            set {
                if (value != _quantity)
                {
                    _subtotal = value;
                    RaisePropertyChanged();
                }
            }
        }

        public int OrderId { get; set; }

        public OrderLineViewModel(OrderLine orderLine)
        {
            Food = orderLine.Food;
            OrderId = orderLine.OrderId;
            Quantity = orderLine.Quantity;
            Subtotal = Food.Price * Quantity;
        }

        public OrderLineViewModel()
        {

        }

        public override string ToString()
        {
            return string.Format("Naam: {0}, \nHoeveelheid: {2}\nSubtotaal: € {3}\n\n", Food.Name, Food.Price, Quantity, Subtotal);
        }
    }
}

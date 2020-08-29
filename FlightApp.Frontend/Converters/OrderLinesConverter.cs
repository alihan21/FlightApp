using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FlightApp.Frontend.Converters
{
    public class OrderLinesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var test = value;

            return test;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using Windows.UI.Xaml.Data;

namespace FlightApp.Frontend.Converters
{
    public class KelvinToCelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string textToShowBeforeValue = parameter as string;

            if (!string.IsNullOrEmpty(textToShowBeforeValue) && value != null)
            {
                double.TryParse(value.ToString(), out double val);

                double celsiusValue = val - 273.15;

                return textToShowBeforeValue + celsiusValue + " °C";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
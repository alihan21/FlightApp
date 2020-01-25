using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FlightApp.Frontend.Converters
{
  public class StringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      string textToShowBeforeValue = parameter as string;

      if (!string.IsNullOrEmpty(textToShowBeforeValue) && value != null)
      {
        return textToShowBeforeValue + value.ToString();
      }

      return "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}

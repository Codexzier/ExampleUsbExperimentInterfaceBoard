using System;
using System.Globalization;
using System.Windows.Data;

namespace ExampleUsbExperimentInterfaceBoard
{
    public class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if(value is bool result)
            {
                result = parameter == null ? result : !result;

                return result;
            }
            
            return false;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

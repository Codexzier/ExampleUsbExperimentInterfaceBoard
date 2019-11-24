using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ExampleUsbExperimentInterfaceBoard
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool result)
            {
                return new SolidColorBrush(result ? Colors.Green : Colors.Black);
            }


            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}

using System;
using System.Globalization;
using System.Windows.Data;

namespace HikiCoffee.AppManager.Converter
{
    public class BackgroundTableFurnitureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? status = value as string;

            if (status == "0")
            {
                return "#d8d8d8";
            }
            else
            {
                return "White";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

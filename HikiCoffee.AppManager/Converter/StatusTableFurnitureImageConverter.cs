using System;
using System.Globalization;
using System.Windows.Data;

namespace HikiCoffee.AppManager.Converter
{
    public class StatusTableFurnitureImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? status = value as string;

            if (status == "0")
            {
                return "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1648398535/HikiCoffee/App_Manager/status_table_1_ywspa2.jpg";
            }
            else
            {
                return "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1648398537/HikiCoffee/App_Manager/status_table_0_lvu91t.jpg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

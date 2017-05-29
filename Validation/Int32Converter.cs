using System;
using System.Globalization;
using System.Windows.Data;

namespace TILab1WPF.Validation
{
    [ValueConversion(typeof(int), typeof(string))]
    public class Int32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int num = System.Convert.ToInt32(value);
            return num.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = System.Convert.ToString(value);
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            int res;
            int.TryParse(str, out res);
            return res;
        }
    }
}

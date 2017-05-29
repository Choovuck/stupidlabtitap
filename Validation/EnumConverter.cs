using System;
using System.Globalization;
using System.Windows.Data;

namespace TILab1WPF.Validation
{
    [ValueConversion(typeof(Enum), typeof(string))]
    public class EnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType().IsEnum)
            {
                return value.ToString();
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = parameter as Type;
            string str = System.Convert.ToString(value);
            if (param != null && param.IsEnum && !string.IsNullOrWhiteSpace(str))
            {
                return Enum.Parse(param, str, true);
            }

            return null;
        }
    }
}

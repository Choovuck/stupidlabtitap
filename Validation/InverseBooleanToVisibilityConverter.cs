﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TILab1WPF.Validation
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            bool flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            return (Visibility)(flag ? 2 : 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value is Visibility)
                return (Visibility)value != Visibility.Visible;
            return false;
        }

        #endregion
    }
}

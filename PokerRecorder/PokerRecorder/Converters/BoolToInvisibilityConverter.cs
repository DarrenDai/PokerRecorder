﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace PokerRecorder.Converters
{
    /// <summary>
    /// 布尔型到非可见转换
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BoolToInvisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

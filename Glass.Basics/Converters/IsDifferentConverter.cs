using System;
using System.Windows.Data;

namespace Glass.Basics.Converters
{
    /// <summary>
    /// WPF/Silverlight ValueConverter : return true if Value differs from Parameter
    /// </summary>
    public class IsDifferentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)new IsEqualConverter().Convert(value, targetType, parameter, culture));
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
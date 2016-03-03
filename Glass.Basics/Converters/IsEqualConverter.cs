using System;
using System.Windows.Data;

namespace Glass.Basics.Converters
{
    /// <summary>
    /// WPF/Silverlight ValueConverter : return true if Value equals Parameter 
    /// </summary>
    public class IsEqualConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            if (targetType != typeof(bool) && targetType != typeof(bool?))
            {
                throw new ArgumentException("Target must be a boolean");
            }

            if (value == null)
            {
                return (parameter == null);
            }

            if (value is String)
            {
                return value.ToString().Equals(parameter.ToString());
            }

            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
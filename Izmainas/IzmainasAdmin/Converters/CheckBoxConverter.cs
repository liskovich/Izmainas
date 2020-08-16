using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace IzmainasAdmin.Converters
{
    public class CheckBoxConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return values.Clone();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

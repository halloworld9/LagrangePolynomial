using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LagrangePolynomial
{
    internal class PointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Point)
            {
                var p = (Point)value;
                return new Thickness(p.X, p.Y, 0, 0);
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness)
            {
                var t = (Thickness)value;
                return new Point(t.Left, t.Bottom);
            }
            return DependencyProperty.UnsetValue;

        }
    }
}

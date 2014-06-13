using System;
using System.Windows.Data;

namespace TipCalc.UI.Wpf.Converters
{
    /*
     * Unfortunately we have to implement different converters for WPF. This is because in their wisdom (not!)
     * Microsoft devided to make IValueConverter inconsistent across platforms. This means we have to implement
     * a native (WPF) version here, but we'll just make it use the existing converter from the Core assembly
     * (which can be used as-is on several (non-Microsoft) platforms.
     */

    class IntPercentageValueConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Use the Core's converter
            var c = new Core.Converters.IntPercentageValueConverter();
            return c.Convert(value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}

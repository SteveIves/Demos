using System;
using Windows.UI.Xaml.Data;

namespace TipCalc.Store.Converters
{
    /*
     * Unfortunately we have to implement different converters for WPF. This is because in their wisdom (not!)
     * Microsoft devided to make IValueConverter inconsistent across platforms. This means we have to implement
     * a native (WPF) version here, but we'll just make it use the existing converter from the Core assembly
     * (which can be used as-is on several (non-Microsoft) platforms.
     */

    public class DoubleCurrencyValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Use the Core's converter
            var c = new Core.Converters.DoubleCurrencyValueConverter();
            return c.Convert(value, targetType, parameter, new System.Globalization.CultureInfo(language));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

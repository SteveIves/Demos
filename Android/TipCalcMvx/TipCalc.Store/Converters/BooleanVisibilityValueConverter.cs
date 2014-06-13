
using System;
using System.Windows;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TipCalc.Store.Converters
{
	public class BooleanVisibilityValueConverter : IValueConverter
    {		
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
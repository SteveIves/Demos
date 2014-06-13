using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalc.Core.Converters
{
    public class DoubleCurrencyValueConverter : MvxValueConverter<double,string>
    {
        protected override string Convert(double value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Format("{0:c}", value);
        }
    }
}

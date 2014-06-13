using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TipCalc.Core.Converters
{
    public class IntPercentageValueConverter : MvxValueConverter<int,string>
    {
        protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Format("{0}%", value);
        }
    }
}

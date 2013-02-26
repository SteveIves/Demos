/////////////////////////////////////////////////////////////
//
// TimeDisplayTick.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Mix07
{
    /// <summary>
    /// Class representing a tick on the time display chart
    /// </summary>
    [XamlResource("Mix07.FlightPicker.TimeDisplayTick.xaml")]
    public class TimeDisplayTick : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the tick</param>
        /// <param name="height">height of the tick</param>
        /// <param name="date">time for the tick</param>
        public TimeDisplayTick(double width, double height, DateTime date)
        {
            // Position the control and children
            RecursivelySetWidthAndHeight(Root, width, height, false);

            // Fill in the time and designator templates
            Run time = Root.FindName("time") as Run;
            if (null != time)
            {
                time.Text = date.ToString(time.Text, CultureInfo.CurrentCulture).Trim();
            }
            Run designator = Root.FindName("designator") as Run;
            if (null != designator)
            {
                designator.Text = date.ToString(designator.Text, CultureInfo.CurrentCulture).Trim();
            }
        }
    }
}

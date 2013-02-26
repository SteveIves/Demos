/////////////////////////////////////////////////////////////
//
// TimeDisplay.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows.Controls;

namespace Mix07
{
    /// <summary>
    /// Class representing the time display
    /// </summary>
    [XamlResource("Mix07.FlightPicker.TimeDisplay.xaml")]
    public class TimeDisplay : MixControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the display</param>
        /// <param name="height">height of the display</param>
        public TimeDisplay(double width, double height)
        {
            // Position the control and children
            RecursivelySetWidthAndHeight(Root, width, height);

            // Display a tick mark for each hour in the day
            DateTime today = DateTime.Now.Date;
            DateTime currentDate = today;
            while (currentDate.Date == today.Date)
            {
                // Calculate position and add tick
                double left = Math.Round((currentDate.Hour / 24.0) * width);
                double nextLeft = Math.Round(((currentDate.Hour + 1) / 24.0) * width);
                TimeDisplayTick tick = new TimeDisplayTick(nextLeft - left, height, currentDate);
                tick.SetValue(Canvas.LeftProperty, left);
                Root.Children.Add(tick);

                currentDate = currentDate.AddHours(1);
            }
        }
    }
}

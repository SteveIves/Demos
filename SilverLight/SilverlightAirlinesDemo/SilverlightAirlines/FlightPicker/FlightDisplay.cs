/////////////////////////////////////////////////////////////
//
// FlightDisplay.cs
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

namespace Mix07
{
    /// <summary>
    /// Class representing a flight
    /// </summary>
    [XamlResource("Mix07.FlightPicker.FlightDisplay.xaml")]
    public class FlightDisplay : MixControl
    {
        /// <summary>
        /// Padding within the border
        /// </summary>
        private const double Padding = 3;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="parent">parent control</param>
        /// <param name="flight">flight instance</param>
        public FlightDisplay(MixControl parent, Flight flight, bool showDepartureTime, bool showArrivalTime)
        {
            // Position the control
            SetValue(Canvas.LeftProperty, ((flight.Departure - flight.Departure.Date).TotalMinutes / (60 * 24.0)) * parent.Root.Width);
            Width = ((flight.Arrival - flight.Departure).TotalMinutes / (60 * 24.0)) * parent.Root.Width;
            Height = parent.Root.Height;

            // Fil in the identifier template
            TextBlock textBlock;
            textBlock = Root.FindName("identifier") as TextBlock;
            if (null != textBlock)
            {
                textBlock.Text = flight.Id;
            }

            // Position the children controls
            RecursivelySetWidthAndHeight(Root, Width, Height);

            // Fill in the from and to templates
            textBlock = Root.FindName("from") as TextBlock;
            if (null != textBlock)
            {
                textBlock.Text = flight.Origin.AirportCode;
                textBlock.SetValue(Canvas.LeftProperty, Padding);
                textBlock.SetValue(Canvas.TopProperty, (Height - textBlock.ActualHeight) / 2);
            }
            textBlock = Root.FindName("to") as TextBlock;
            if (null != textBlock)
            {
                textBlock.Text = flight.Destination.AirportCode;
                textBlock.SetValue(Canvas.TopProperty, (Height - textBlock.ActualHeight) / 2);
                textBlock.SetValue(Canvas.LeftProperty, Width - textBlock.ActualWidth - Padding);
            }

            // Fill in the departure and arrival times
            if (showDepartureTime)
            {
                textBlock = Root.FindName("departs") as TextBlock;
                if (null != textBlock)
                {
                    textBlock.Opacity = 1;
                    textBlock.Text = flight.Departure.ToString(textBlock.Text, CultureInfo.CurrentCulture);
                    textBlock.SetValue(Canvas.LeftProperty, -Padding - textBlock.ActualWidth);
                    textBlock.SetValue(Canvas.TopProperty, (Height - textBlock.ActualHeight) / 2);
                }
            }
            if (showArrivalTime)
            {
                textBlock = Root.FindName("arrives") as TextBlock;
                if (null != textBlock)
                {
                    textBlock.Opacity = 1;
                    textBlock.Text = flight.Arrival.ToString(textBlock.Text, CultureInfo.CurrentCulture);
                    textBlock.SetValue(Canvas.LeftProperty, Width + Padding);
                    textBlock.SetValue(Canvas.TopProperty, (Height - textBlock.ActualHeight) / 2);
                }
            }
        }
    }
}

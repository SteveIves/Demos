/////////////////////////////////////////////////////////////
//
// ItineraryDisplay.cs
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
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Mix07
{
    /// <summary>
    /// Class representing the itinerary display
    /// </summary>
    [XamlResource("Mix07.FlightPicker.ItineraryDisplay.xaml")]
    public class ItineraryDisplay : MixControl
    {
        /// <summary>
        /// Height of the connection elements
        /// </summary>
        private const double ConnectionHeight = 2;

        private ItineraryPicker _flightPicker;
        private Itinerary _itinerary;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width">width of the itinerary display</param>
        /// <param name="height">height of the itinerary display</param>
        /// <param name="flightPicker">parent itinerary picker</param>
        /// <param name="itinerary">itinerary to display</param>
        public ItineraryDisplay(double width, double height, ItineraryPicker flightPicker, Itinerary itinerary)
        {
            // Position the control
            _flightPicker = flightPicker;
            _itinerary = itinerary;
            RecursivelySetWidthAndHeight(Root, width, height, true);

            // Fill in the price template
            TextBlock priceBlock = Root.FindName("price") as TextBlock;
            if (priceBlock != null)
            {
                priceBlock.Text = itinerary.Price.ToString(priceBlock.Text, CultureInfo.CurrentCulture);
                priceBlock.SetValue(Canvas.LeftProperty, 0);
                priceBlock.SetValue(Canvas.TopProperty, (height - priceBlock.ActualHeight) / 2);
            }

            // Display the flights in the itinerary
            double lastX = 0;
            for(int i = 0 ; i < _itinerary.Flights.Count ; i++)
            {
                FlightDisplay flightDisplay = new FlightDisplay(this, _itinerary.Flights[i], (0 == i), (i == _itinerary.Flights.Count - 1));
                Root.Children.Add(flightDisplay);
                if (0 != lastX)
                {
                    FlightConnection flightConnection = new FlightConnection((double)flightDisplay.GetValue(Canvas.LeftProperty) - lastX, ConnectionHeight);
                    flightConnection.SetValue(Canvas.LeftProperty, lastX);
                    flightConnection.SetValue(Canvas.TopProperty, (height - ConnectionHeight) / 2);
                    Root.Children.Add(flightConnection);
                }
                lastX = (double)flightDisplay.GetValue(Canvas.LeftProperty) + flightDisplay.Width;
            }

            // Hook up the event handlers
            MouseEnter += new MouseEventHandler(ItineraryDisplay_MouseEnter);
            MouseLeave += new EventHandler(ItineraryDisplay_MouseLeave);
            MouseLeftButtonDown += new MouseEventHandler(ItineraryDisplay_MouseLeftButtonDown);
        }

        /// <summary>
        /// Handler for mouse going over the itinerary display
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void ItineraryDisplay_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!_flightPicker.Committed)
            {
                ShowHighlight();
                _flightPicker.FireItinerarySelected(this, false);
            }
        }

        /// <summary>
        /// Handler for mouse leaving the itinerary display
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void ItineraryDisplay_MouseLeave(object sender, EventArgs e)
        {
            if (!_flightPicker.Committed)
            {
                HideHighlight();
                _flightPicker.FireItinerarySelected(null, false);
            }
        }

        /// <summary>
        /// Handler for mouse being clicked on the itinerary display
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        void ItineraryDisplay_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            ShowHighlight();
            _flightPicker.FireItinerarySelected(this, true);
        }

        /// <summary>
        /// Show the highlight
        /// </summary>
        private void ShowHighlight()
        {
            // Play storyboard and fire the associated event
            Storyboard storyboard = Root.FindName("ShowHighlight") as Storyboard;
            if (null != storyboard)
            {
                storyboard.Begin();
            }
        }

        /// <summary>
        /// Hide the highlight
        /// </summary>
        public void HideHighlight()
        {
            // Play storyboard and fire the associated event
            Storyboard storyboard = Root.FindName("HideHighlight") as Storyboard;
            if (null != storyboard)
            {
                storyboard.Begin();
            }
        }

        /// <summary>
        /// The itinerary represented by this display element
        /// </summary>
        public Itinerary Itinerary
        {
            get
            {
                return _itinerary;
            }
        }
    }
}

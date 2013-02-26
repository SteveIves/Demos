/////////////////////////////////////////////////////////////
//
// Default.xaml.cs
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
    /// Default canvas for the project
    /// </summary>
    public partial class DefaultCanvas : Canvas
    {
        /// <summary>
        /// Handles the Loaded event
        /// </summary>
        /// <param name="obj">object</param>
        /// <param name="evt">event args</param>
        private void PageLoaded(object obj, EventArgs evt)
        {
            InitializeComponent();

            // Hook up event handlers
            map.DestinationSelected += new EventHandler(map_DestinationSelected);
            calendar.DateRangeSelected += new EventHandler(calendar_DateRangeSelected);
            itineraryPicker.ItinerarySelected += new EventHandler(flightPicker_ItinerarySelected);
        }

        /// <summary>
        /// Event handler for map selections
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void map_DestinationSelected(object sender, EventArgs e)
        {
            itineraryPicker.ShowItineraries(map.Origin, map.Destination, calendar.SelectionStartDate);
        }

        /// <summary>
        /// Event handler for calendar selections
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        private void calendar_DateRangeSelected(object sender, EventArgs e)
        {
            itineraryPicker.ShowItineraries(map.Origin, map.Destination, calendar.SelectionStartDate);
        }

        /// <summary>
        /// Event handler for flight picker selections
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event args</param>
        void flightPicker_ItinerarySelected(object sender, EventArgs e)
        {
            map.ShowItinerary(itineraryPicker.Itinerary);
        }
    }
}

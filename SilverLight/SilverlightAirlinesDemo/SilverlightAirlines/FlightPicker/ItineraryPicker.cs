/////////////////////////////////////////////////////////////
//
// ItineraryPicker.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Mix07
{
    /// <summary>
    /// Class representing the itinerary picker
    /// </summary>
    [XamlResource("Mix07.FlightPicker.ItineraryPicker.xaml")]
    public class ItineraryPicker : MixControl
    {
        /// <summary>
        /// Event fired when an itinerary is selected
        /// </summary>
        public event EventHandler ItinerarySelected;

        /// <summary>
        /// Size of the interior margin
        /// </summary>
        private const double MarginSize = 5;

        /// <summary>
        /// Height of an itinerary
        /// </summary>
        private const double ItineraryHeight = 15;

        /// <summary>
        /// Top for the first itinerary
        /// </summary>
        private const double StartingItineraryTop = 28;

        /// <summary>
        /// Padding between itineraries
        /// </summary>
        private const double ItineraryPadding = 4;

        private ItineraryDisplay _selectedItineraryDisplay;
        private bool _committed;
        private List<ItineraryDisplay> _displayedItineraryDisplays;

        /// <summary>
        /// Constructor
        /// </summary>
        public ItineraryPicker()
        {
            _displayedItineraryDisplays = new List<ItineraryDisplay>();
        }

        /// <summary>
        /// Handler for OnLoaded event
        /// </summary>
        /// <param name="e">event args</param>
        protected override void OnLoaded(EventArgs e)
        {
            base.OnLoaded(e);

            // Size the control and children
            RecursivelySetWidthAndHeight(Root, Width, Height);

            // Add a time display
            TimeDisplay timeDisplay = new TimeDisplay(Width - (2 * MarginSize), Height - (2 * MarginSize));
            timeDisplay.SetValue(Canvas.LeftProperty, MarginSize);
            timeDisplay.SetValue(Canvas.TopProperty, MarginSize);
            Root.Children.Add(timeDisplay);
        }

        /// <summary>
        /// Show the available itineraries for the specified trip
        /// </summary>
        /// <param name="origin">origin city</param>
        /// <param name="destination">destination city</param>
        /// <param name="departure">departure time</param>
        public void ShowItineraries(City origin, City destination, DateTime? departure)
        {
            // Reset state
            FireItinerarySelected(null, false);

            // Clear any displayed itineraries
            foreach (ItineraryDisplay id in _displayedItineraryDisplays)
            {
                Root.Children.Remove(id);
            }
            _displayedItineraryDisplays.Clear();

            if((null != origin) && (null != destination) && (null != departure))
            {
                // Get the itineraries (if available)
                Itinerary[] itineraries = FlightService.GetItineraries(origin, destination, departure.Value);
                if (null != itineraries)
                {
                    // Calculate the location
                    double top = StartingItineraryTop;
                    double height = ItineraryHeight;
                    double padding = ItineraryPadding;
                    foreach (Itinerary itinerary in itineraries)
                    {
                        // Display each itinerary
                        ItineraryDisplay itineraryDisplay = new ItineraryDisplay(Width - (2 * MarginSize), height, this, itinerary);
                        itineraryDisplay.SetValue(Canvas.LeftProperty, MarginSize);
                        itineraryDisplay.SetValue(Canvas.TopProperty, top);
                        Root.Children.Add(itineraryDisplay);
                        _displayedItineraryDisplays.Add(itineraryDisplay);

                        top += height + padding;
                    }
                }
            }
        }

        /// <summary>
        /// Fire the ItinerarySelected event
        /// </summary>
        /// <param name="itinerary">specified itinerary</param>
        /// <param name="commit">true iff comitting the selection</param>
        public void FireItinerarySelected(ItineraryDisplay itineraryDisplay, bool commit)
        {
            // Note whether the selection is changing
            bool changing = (itineraryDisplay != _selectedItineraryDisplay);

            // If committing to a new itinerary, hide the old highlight
            if (commit && _committed && (null != _selectedItineraryDisplay) && changing)
            {
                _selectedItineraryDisplay.HideHighlight();
            }

            // Store the new settings
            _selectedItineraryDisplay = itineraryDisplay;
            _committed = commit;

            // Fire the event if the selection has changed
            if (changing)
            {
                EventHandler handler = ItinerarySelected;
                if (null != handler)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets the selected itinerary
        /// </summary>
        public Itinerary Itinerary
        {
            get
            {
                return (null != _selectedItineraryDisplay) ? _selectedItineraryDisplay.Itinerary : null;
            }
        }

        /// <summary>
        /// Returns whether the selection is committed
        /// </summary>
        public bool Committed
        {
            get
            {
                return _committed;
            }
        }
    }
}

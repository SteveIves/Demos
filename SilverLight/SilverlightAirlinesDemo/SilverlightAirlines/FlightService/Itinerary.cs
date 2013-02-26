/////////////////////////////////////////////////////////////
//
// Itinerary.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;

namespace Mix07
{
    /// <summary>
    /// Itinerary for a trip containing (potentially) multiple flights
    /// </summary>
    public class Itinerary
    {
        private List<Flight> _flights;
        private decimal _price;

        public Itinerary()
        {
            _flights = new List<Flight>();
        }

        /// <summary>
        /// List of flights in the itinerary
        /// </summary>
        public IList<Flight> Flights
        {
            get
            {
                return _flights;
            }
        }

        /// <summary>
        /// Price of the itinerary
        /// </summary>
        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
    }
}

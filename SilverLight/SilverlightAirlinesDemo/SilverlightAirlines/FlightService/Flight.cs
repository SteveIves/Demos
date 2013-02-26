/////////////////////////////////////////////////////////////
//
// Flight.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Globalization;

namespace Mix07
{
    /// <summary>
    /// Represents a flight from one city to another
    /// </summary>
    public class Flight
    {
        private int _id;
        private City _from;
        private City _to;
        private DateTime _departure;
        private DateTime _arrival;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">flight ID</param>
        /// <param name="from">origin city</param>
        /// <param name="to">destination city</param>
        /// <param name="departure">departure time</param>
        /// <param name="arrival">arrival time</param>
        public Flight(int id, City from, City to, DateTime departure, DateTime arrival)
        {
            _id = id;
            _from = from;
            _to = to;
            _departure = departure;
            _arrival = arrival;
        }

        /// <summary>
        /// ID of the flight (of the form "SL12")
        /// </summary>
        public string Id
        {
            get
            {
                return "SL" + _id.ToString("00", CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Origin city of the flight
        /// </summary>
        public City Origin
        {
            get
            {
                return _from;
            }
        }

        /// <summary>
        /// Destination city of the flight
        /// </summary>
        public City Destination
        {
            get
            {
                return _to;
            }
        }

        /// <summary>
        /// Departure time of the flight
        /// </summary>
        public DateTime Departure
        {
            get
            {
                return _departure;
            }
        }

        /// <summary>
        /// Arrival time of the flight
        /// </summary>
        public DateTime Arrival
        {
            get
            {
                return _arrival;
            }
        }
    }
}

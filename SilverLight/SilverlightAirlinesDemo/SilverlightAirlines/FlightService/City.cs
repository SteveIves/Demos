/////////////////////////////////////////////////////////////
//
// City.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows;

namespace Mix07
{
    /// <summary>
    /// A city (with an airport) to be displayed on the map and referenced by flights.
    /// </summary>
    public class City
    {
        private string _name;
        private string _airportCode;
        private Point _coordinates;

        /// <summary>
        /// Name of the city
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Airport code of the major airport in the city
        /// </summary>
        public string AirportCode
        {
            get
            {
                return _airportCode;
            }
            set
            {
                _airportCode = value;
            }
        }

        /// <summary>
        /// Coordinates of the city (relative to the map)
        /// </summary>
        public Point Coordinates
        {
            get
            {
                return _coordinates;
            }
            set
            {
                _coordinates = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the city</param>
        /// <param name="airportCode">Airport code of the major airport in the city</param>
        /// <param name="coordinates">Coordinates of the city (relative to the map)</param>
        public City(string name, string airportCode, Point coordinates)
        {
            _name = name;
            _airportCode = airportCode;
            _coordinates = coordinates;
        }

        /// <summary>
        /// Compute the distance between two cities based on their coordinates
        /// </summary>
        /// <param name="destination">Destination</param>
        /// <returns>Distance between the two cities</returns>
        public double DistanceTo(City destination)
        {
            if (destination == null || destination == this)
            {
                return 0;
            }
            double dX = _coordinates.X - destination._coordinates.X;
            double dY = _coordinates.Y - destination._coordinates.Y;
            return Math.Sqrt(dX * dX + dY * dY);
        }
    }
}

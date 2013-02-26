/////////////////////////////////////////////////////////////
//
// MapPointCollection.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows;

namespace Mix07
{
    /// <summary>
    /// Collection of MapPoints
    /// </summary>
    public sealed class MapPointCollection : ICollection<MapPoint>
    {
        /// <summary>
        /// Map that contains the collection of points
        /// </summary>
        private Map _map;

        /// <summary>
        /// Internal list of points
        /// </summary>
        private List<MapPoint> _points;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="map">Map containing this collection of points</param>
        public MapPointCollection(Map map)
        {
            _map = map;
            _points = new List<MapPoint>();
        }

        /// <summary>
        /// Get the MapPoint corresponding to a city name
        /// </summary>
        /// <param name="name">Name of the city</param>
        /// <returns>MapPoint corresponding to the city name, or null if not found</returns>
        public MapPoint this[string name]
        {
            get
            {
                foreach (MapPoint point in _points)
                {
                    if (point.City != null && string.Compare(point.City.Name, name, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return point;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// Get the MapPoint corresponding to a location on the Map
        /// </summary>
        /// <param name="location">Location on the Map</param>
        /// <returns>MapPoint corresponding to the location, or null if not found</returns>
        public MapPoint GetMapPoint(Point location)
        {
            foreach (MapPoint point in _points)
            {
                if (point.RootBounds.Contains(location))
                {
                    return point;
                }
            }
            return null;
        }

        /// <summary>
        /// Add a new city (by creating a MapPoint)
        /// </summary>
        /// <param name="city">City to add</param>
        public void Add(City city)
        {
            Add(new MapPoint(city));
        }

        /// <summary>
        /// Add a MapPoint
        /// </summary>
        /// <param name="item">MapPoint to add</param>
        public void Add(MapPoint item)
        {
            _map.PointContainer.Children.Add(item);
            _points.Add(item);
        }

        /// <summary>
        /// Clear the points
        /// </summary>
        public void Clear()
        {
            foreach (MapPoint point in _map.PointContainer.Children)
            {
                _map.PointContainer.Children.Remove(point);
            }
            _points.Clear();
        }

        /// <summary>
        /// Check if the map contains a point
        /// </summary>
        /// <param name="item">MapPoint to check for</param>
        /// <returns>True if the map contains the point, false otherwise</returns>
        public bool Contains(MapPoint item)
        {
            return _points.Contains(item);
        }

        /// <summary>
        /// Copy the collection into an array of points
        /// </summary>
        /// <param name="array">Array to copy into</param>
        /// <param name="arrayIndex">Index of the array to begin copying</param>
        public void CopyTo(MapPoint[] array, int arrayIndex)
        {
            _points.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Number of MapPoints
        /// </summary>
        public int Count
        {
            get
            {
                return _points.Count;
            }
        }

        /// <summary>
        /// The collection is not readonly
        /// </summary>
        bool ICollection<MapPoint>.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a MapPoint
        /// </summary>
        /// <param name="item">MapPoint</param>
        /// <returns>True if the point was removed, false otherwise</returns>
        public bool Remove(MapPoint item)
        {
            _map.PointContainer.Children.Remove(item);
            return _points.Remove(item);
        }

        /// <summary>
        /// Get an enumerator for the points
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<MapPoint> GetEnumerator()
        {
            return _points.GetEnumerator();
        }

        /// <summary>
        /// Get an enumerator for the points
        /// </summary>
        /// <returns>Enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

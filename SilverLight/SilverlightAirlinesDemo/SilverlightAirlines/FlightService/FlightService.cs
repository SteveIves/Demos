/////////////////////////////////////////////////////////////
//
// FlightService.cs
//
// © 2007 Microsoft Corporation. All Rights Reserved.
//
// This file is licensed with terms as outlined here:
// http://go.microsoft.com/fwlink/?LinkID=89145&clcid=0x409
//
/////////////////////////////////////////////////////////////

using System;
using System.Windows;
using System.Collections.Generic;

namespace Mix07
{
    /// <summary>
    /// Service providing flight information
    /// </summary>
    public static class FlightService
    {
        // Constraints used to generate random itineraries
        private const int MaximumItineraries = 5;
        private const int MaximumItineraryHops = 2;
        private const int MinimumLayoverMinutes = 25;
        private const int MaximumLayoverMinutes = 180;
        private const int MinimumFlightMinutes = 120;
        private const int MaximumFlightMinutes = 480;
        private const double MaximumDeviation = 1.25;
        private static double? MaximumDistance = null;

        // Constraints used to price itineraries
        private const decimal MaximumPrice = 1000;
        private const double DiscountPerHop = .04;
        private const double UrgencyMultiplier = 1.5;
        private const int UrgencyDuration = 30;

        /// <summary>
        /// Cache used to track itineraries between two cities on a given date
        /// (it's not collision-free, we just want to make sure that the same search parameters
        /// return the same flights given that we're randomly creating them)
        /// </summary>
        private static Dictionary<int, Itinerary[]> _itineraryCache = new Dictionary<int, Itinerary[]>();

        /// <summary>
        /// List of all cities
        /// </summary>
        private static City[] _cities = new City[]
        {
            new City("Anchorage", "ANC", new Point(143, 139)),
            new City("Albuquerque", "ABQ", new Point(482, 263)),
            new City("Atlanta", "ATL", new Point(759, 282)),
            new City("Bismarck", "BIS", new Point(566, 94)),
            new City("Boise", "BOI", new Point(397, 125)),
            new City("Boston", "BOS", new Point(892, 129)),
            new City("Burlington", "BTV", new Point(862, 103)),
            new City("Charlotte", "CLT", new Point(801, 256)),
            new City("Chicago", "CHI", new Point(706, 164)),
            new City("Columbia", "CAE", new Point(806, 278)),
            new City("Columbus", "CMH", new Point(766, 187)),
            new City("Dallas", "DAL", new Point(608, 312)),
            new City("Denver", "DEN", new Point(516, 204)),
            new City("Des Moines", "DSM", new Point(641, 174)),
            new City("Detroit", "DTW", new Point(755, 155)),
            new City("Green Bay", "GRB", new Point(701, 128)),
            new City("Helena", "HLN", new Point(441, 85)),
            new City("Honolulu", "HNL", new Point(147, 292)),
            new City("Las Vegas", "LAS", new Point(385, 231)),
            new City("Los Angeles", "LAX", new Point(340, 259)),
            new City("Louisville", "SDF", new Point(732, 224)),
            new City("Miami", "MIA", new Point(830, 393)),
            new City("Memphis", "MEM", new Point(691, 270)),
            new City("New York", "NYC", new Point(865, 157)),
            new City("New Orleans", "MSY", new Point(697, 348)),
            new City("Phoenix", "PHX", new Point(416, 279)),
            new City("Portland", "PDX", new Point(333, 79)),
            new City("Philadelphia", "PHL", new Point(853, 173)),
            new City("Richmond", "RIC", new Point(828, 216)),
            new City("Salt Lake City", "SLC", new Point(433, 175)),
            new City("San Antonio", "SAT", new Point(580, 356)),
            new City("San Francisco", "SFO", new Point(306, 188)),
            new City("Seattle", "SEA", new Point(352, 43)),
            new City("Springfield", "SGF", new Point(649, 240)),
            new City("Tulsa", "TUL", new Point(618, 261)),
            new City("Wichita", "ICT", new Point(616, 214)),
        };

        /// <summary>
        /// Get all the destinations of our airline
        /// </summary>
        /// <returns>Array of all cities</returns>
        public static City[] GetDestinations()
        {
            return _cities;
        }

        /// <summary>
        /// Get possible itineraries between an origin and destination
        /// </summary>
        /// <param name="origin">Origin of the flight</param>
        /// <param name="destination">Destination of the flight</param>
        /// <param name="departure">Date of the flight</param>
        /// <returns>Possible iteneraries</returns>
        public static Itinerary[] GetItineraries(City origin, City destination, DateTime departure)
        {
            Itinerary[] itineraries;
            int hash = ComputeHash(origin, destination, departure);
            if (!_itineraryCache.TryGetValue(hash, out itineraries))
            {
                itineraries = CreateRandomItineraries(origin, destination, departure);
                _itineraryCache[hash] = itineraries;
            }
            return itineraries;
        }

        /// <summary>
        /// Get possible itineraries between an origin and destination that have been cached
        /// </summary>
        /// <param name="origin">Origin of the flight</param>
        /// <param name="destination">Destination of the flight</param>
        /// <param name="departure">Date of the flight</param>
        /// <returns>Hashcode for the itinerary</returns>
        private static int ComputeHash(City origin, City destination, DateTime departure)
        {
            // Take the bottom half of the origin's hash code with the top half
            // of the destination's hash code and xor it with the date's hash code
            return ((origin.Name.GetHashCode() & 65535) | (destination.Name.GetHashCode() & -65536)) ^ departure.GetHashCode();
        }

        /// <summary>
        /// Create possible itineraries between an origin and destination
        /// </summary>
        /// <param name="origin">Origin of the flight</param>
        /// <param name="destination">Destination of the flight</param>
        /// <param name="departure">Date of the flight</param>
        /// <returns>Possible iteneraries</returns>
        private static Itinerary[] CreateRandomItineraries(City origin, City destination, DateTime departure)
        {
            // Ignore flights for days in the past
            if (departure < DateTime.Today)
            {
                return new Itinerary[] { };
            }

            // Create a random number generator
            Random random = new Random(Environment.TickCount);

            // Compute the maximum distance so we can make flight times approximately relative
            if (MaximumDistance == null)
            {
                double maxX = 0;
                double maxY = 0;
                foreach (City city in _cities)
                {
                    if (city.Coordinates.X > maxX)
                    {
                        maxX = city.Coordinates.X;
                    }
                    if (city.Coordinates.Y > maxY)
                    {
                        maxY = city.Coordinates.Y;
                    }
                }
                MaximumDistance = Math.Sqrt(maxX * maxX + maxY * maxY);
            }

            // Compute the total distance - any hops must be less than this or
            // we won't include them (this prevents us from creating a stop in New
            // York when we're going from Phoenix to LA)
            double totalDistance = origin.DistanceTo(destination);

            // Create a list of cities that aren't too far out of the way
            // between the start and destination
            List<City> colinearCities = new List<City>();
            foreach (City city in _cities)
            {
                if (city != origin && city != destination && ((origin.DistanceTo(city) + city.DistanceTo(destination)) < (totalDistance * MaximumDeviation)))
                {
                    colinearCities.Add(city);
                }
            }

            // Create the itineraries
            List<Itinerary> itineraries = new List<Itinerary>();
            for (int i = 0; i < MaximumItineraries; i++)
            {
                // Create a new itinerary starting at the origin city sometime on
                // the departure date between 2:00am and 7:00pm
                Itinerary itinerary = new Itinerary();
                City last = origin;
                DateTime depart = departure.Date.AddMinutes((2*60) + random.Next(19*60));
                DateTime arrive;

                // Create a list of the remaining cities that we'll prune down
                // with each hop we add to the itinerary
                List<City> remainingCities = new List<City>(colinearCities);

                // Determine the number of hops (using a logarithmic scale to favor
                // multiple hops to show off the demo)
                int numHops = (int) (Math.Log(random.Next(2, (4 << MaximumItineraryHops) - 1)) / Math.Log(2));

                // Create each hop of the itinerary
                for (int j = 1; j < numHops && remainingCities.Count > 0; j++)
                {
                    // Get a random city for the hop, but ensure it's not too far out of the way
                    City next = remainingCities[random.Next(remainingCities.Count)];
                    double distance = last.DistanceTo(next);
                    double remainingDistance = next.DistanceTo(destination);
                    if (remainingDistance > last.DistanceTo(destination))
                    {
                        j--;
                        continue;
                    }

                    // Prune the list of remaining cities so we don't go too far
                    // out of the way on any subsequent hops
                    remainingCities.RemoveAll(delegate(City c) { return c.DistanceTo(destination) >= remainingDistance || next.DistanceTo(c) >= remainingDistance; });

                    // Determine the length of the trip (including a little randomization for wind/misc delays)
                    arrive = depart.AddMinutes(Math.Max(((distance / totalDistance) * MaximumFlightMinutes) * (.95 + random.NextDouble() / 10.0), MinimumFlightMinutes));
                    itinerary.Flights.Add(new Flight(random.Next(100), last, next, depart, arrive));

                    // Add the layover time
                    depart = arrive.AddMinutes(random.Next(MinimumLayoverMinutes, MaximumLayoverMinutes));
                    last = next;
                }

                // Add the last leg of the trip (but ignore any trips that take more than a day)
                arrive = depart.AddMinutes(Math.Max(((last.DistanceTo(destination) / totalDistance) * MaximumFlightMinutes) * (.95 + random.NextDouble() / 10.0), MinimumFlightMinutes));
                if(departure.Date.AddHours(23) < arrive)
                {
                    i--;
                    continue;
                }
                itinerary.Flights.Add(new Flight(random.Next(100), last, destination, depart, arrive));

                // Compute the base price as a percentage of the distance flown
                decimal price = ((decimal) (totalDistance / MaximumDistance)) * MaximumPrice;

                // Subtract a discount for multiple hops
                price *= (decimal) (1.0 - DiscountPerHop * (itinerary.Flights.Count - 1));

                // Increase the rate by an amount proportional to the urgency (i.e. the UrgencyMultiplier
                // is spread across the UrgencyDuration...  so half way between now and the UrgencyDuration
                // we'll pay half the UrgencyMultiplier)
                price *= (decimal) Math.Max(1.0, 1.0 + (UrgencyMultiplier - 1.0) * (1.0 - ((double) (departure - DateTime.Today).Days) / ((double) UrgencyDuration)));

                // Add a little randomization to finish off the price
                price *= (decimal) (.975 + random.NextDouble() / 20.0);
                itinerary.Price = price;

                // Add the itinerary
                itineraries.Add(itinerary);
            }

            // Sort the flights by initial departure
            itineraries.Sort(delegate(Itinerary a, Itinerary b) { return a.Flights[0].Departure.CompareTo(b.Flights[0].Departure); });
            return itineraries.ToArray();
        }
    }
}

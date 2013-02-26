using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SteveIves.WebServices
{
    /// <summary>
    /// Summary description for FlightTrackerService
    /// </summary>
    [WebService(Namespace = "http://www.steveives.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FlightTrackerService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Country> GetCountries()
        {
            FlightTrackDbDataContext db = new FlightTrackDbDataContext();
            IEnumerable<Country> results = from p in db.Countries
                   select p;
            return results.ToList<Country>();
        }

        [WebMethod]
        public List<Airport> GetAirports()
        {
            FlightTrackDbDataContext db = new FlightTrackDbDataContext();
            IEnumerable<Airport> results = from p in db.Airports
                   select p;
            return results.ToList<Airport>(); ;
        }

        [WebMethod]
        public List<Airline> GetAirlines()
        {
            FlightTrackDbDataContext db = new FlightTrackDbDataContext();
            IEnumerable<Airline> results = from p in db.Airlines
                   select p;
            return results.ToList<Airline>();
        }
    }
}

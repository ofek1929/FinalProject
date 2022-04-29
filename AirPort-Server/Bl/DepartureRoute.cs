using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class DepartingRoute : IDepartureRoute
    {
        public IList<IAirportStation> Stations { get; }

        public DepartingRoute(IAirportStations airportStations)
        {
            Stations = new List<IAirportStation>();
            
            Stations.Add(airportStations.Get("6"));
            Stations.Add(airportStations.Get("7"));
            Stations.Add(airportStations.Get("8"));
            Stations.Add(airportStations.Get("4"));
            Stations.Add(airportStations.Get("9"));

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class LandingRoute: ILandingRoute
    {
        public IList<IAirportStation> Stations { get; }


        public LandingRoute(IAirportStations airportStations)
        {
            Stations = new List<IAirportStation>();

            Stations.Add(airportStations.Get("1"));
            Stations.Add(airportStations.Get("2"));
            Stations.Add(airportStations.Get("3"));
            Stations.Add(airportStations.Get("4"));
            Stations.Add(airportStations.Get("5"));
            Stations.Add(airportStations.Get("6"));
            Stations.Add(airportStations.Get("7"));
            
        }
    }
}

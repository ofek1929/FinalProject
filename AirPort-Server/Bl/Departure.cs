using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class Departure : IDeparture
    {
        
        private readonly IDepartureRoute _route;

        public Departure(IDepartureRoute route)
        {
            
            this._route = route;
        }

        public void Departe(Plane plane, IAirportLogic logic)
        {
            Task.Run(() =>
            {
                IAirportStation current = null;
                for (int i = 0; i < _route.Stations.Count; i++)
                {
                    var station = _route.Stations[i];
                    if (station.Id != "6" )
                    {
                        if (current != null)
                        {
                            current.ExitStation(logic);
                            current = null;
                        }

                        station.EnterStation(plane, logic);
                        current = station;
                    }
                    else
                    {
                        current = null;
                        station.Move(plane, _route.Stations[i], logic);
                        i++;
                    }
                }
                //need to leave to last station before 
                _route.Stations[_route.Stations.Count - 1].ExitStation(logic);
                logic.DepartureComplete(plane);
            });


        }
    }
}

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class Landing : ILanding
    {
        private readonly ILandingRoute _route;
       

        public Landing(ILandingRoute route)
        {
            _route = route;
           
        }

        public void Land(Plane plane , IAirportLogic logic)
        {
            Task.Run(() =>
            {
                //IAirportStation current = null;
                for (int i = 0; i < _route.Stations.Count; i++)
                {
                    var station = _route.Stations[i];
                    if (station.Id != "6" )
                    {
                        //if (current != null)
                        //{
                        //    current.ExitStation(logic);
                        //    current = null;
                        //}

                        station.EnterStation(plane, logic);
                        //current = station;
                    }
                    else
                    {
                        //current = null;
                        station.Move(plane, _route.Stations[i], logic);
                        i++;
                    }
                }
                logic.LandingComplete(plane);
            });
        }

 
    }
}

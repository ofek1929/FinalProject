using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface IAirportLogic
    {
        //public void EnterStation(string station, Plane plane);
        //public void ExitStation(string station, Plane plane);
        public void Start();
        public void LandingComplete(Landing landing);
        public void LandingComplete(Plane palne);
        public void DepartureComplete(Plane departure);
        
        public void AddToHistory(string id, Plane plane, DateTime time, bool isExit);

        public void NewLanding(DateTime time);
        void NewDeparting(DateTime time);
    }
}

using Dal.Models;
using System;
using System.Collections.Generic;

namespace Dal.Repositorys
{
    public interface IRepository
    {
        public List<Departure> GetDepartures();
        public List<Landing> GetLandings();
        public List<History> GetHistories();
        public List<Station> GetAllStations();
        public Plane GetPlane(int planeId);
        public void ExitStation(string stationName, Plane plane, DateTime time);
        public void EnterStation(string stationName, Plane plane, DateTime time);
        public void EnterTerminal(string stationName, Plane plane, DateTime time);
        public Plane AddNewPlane(bool isLanding);
        public void AddLanding(Plane plane, DateTime time);
        public void AddDeparture(Plane plane, DateTime time);

    }
}
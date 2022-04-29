using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal.Repositorys
{
    public class Repository : IRepository
    {
        FinalProjectContext _context = new FinalProjectContext();
        public Repository()
        {
           
        }
        public List<Station> GetAllStations()
        {
            return _context.Stations.ToList();
        }

        public List<History> GetHistories()
        {
            return _context.Histories.ToList();
        }
        public List<Departure> GetDepartures()
        {
            return _context.Departures.ToList();
        }


        public List<Landing> GetLandings()
        {
            return _context.Landings.ToList();

        }


        public void EnterStation(string stationName, Plane plane, DateTime time)
        {
            //Station s = _context.Stations.FirstOrDefault(x => x.StationName == stationName);
            //s.PlaneId = plane.PlaneId;
            _context.Stations.FirstOrDefault(x => x.StationName == stationName).PlaneId = plane.PlaneId;
            _context.SaveChanges();
            
            History h = new History { Id = GetHistoryMaxId(), StationName = stationName, PlaneId = plane.PlaneId, EnterTime = time };            
            plane.History = h;
            _context.Histories.Add(h);
            _context.SaveChanges();

        }
        public void EnterTerminal(string stationName, Plane plane, DateTime time)
        {
            History h = new History { Id = GetHistoryMaxId(), StationName = stationName, PlaneId = plane.PlaneId, EnterTime = time };
            plane.History = h;
            _context.Histories.Add(h);
            _context.SaveChanges();
        }
        public void ExitStation(string stationName, Plane plane, DateTime time)
        {
            Station s = _context.Stations.FirstOrDefault(x => x.StationName == stationName);
            s.PlaneId = 0;
            _context.SaveChanges();
            History t = _context.Histories.FirstOrDefault(s => s.PlaneId == plane.PlaneId && s.StationName == stationName);
            t.LeavingTine = time;
            _context.SaveChanges();
        }

        public Plane AddNewPlane(bool isLanding)
        {
            int maxId;
            
            if (_context.Planes.OrderByDescending(t => t.PlaneId).FirstOrDefault()== null)
            {
                maxId = 1;
            }
            else
            {
                maxId = _context.Planes.OrderByDescending(t => t.PlaneId).FirstOrDefault().PlaneId+1;
                
            }
            Plane newPlane = new Plane { PlaneId = maxId, IsLanding = isLanding };
            _context.Planes.Add(newPlane);
            _context.SaveChanges();
            return newPlane;
        }

        public Plane GetPlane(int planeId)
        {
            return _context.Planes.FirstOrDefault(x => x.PlaneId == planeId);
        }
        private int GetHistoryMaxId()
        {
            if (_context.Histories.OrderByDescending(x => x.Id).FirstOrDefault() == null)
            {
                return 1;
            }
            return _context.Histories.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            
        }

        public void AddLanding(Plane plane, DateTime time)
        {
            
            if (_context.Departures.OrderByDescending(x => x.Id).FirstOrDefault()==null)
            {
                _context.Landings.Add(new Landing { Id = 1, PlaneId = plane.PlaneId, Time = time });
            }
            else _context.Landings.Add(new Landing { Id = _context.Departures.OrderByDescending(x => x.Id).FirstOrDefault().Id+1, PlaneId = plane.PlaneId, Time = time });
            _context.SaveChanges();
        }

        public void AddDeparture(Plane plane, DateTime time)
        {
            
            if (_context.Departures.OrderByDescending(x => x.Id).FirstOrDefault()==null)
            {
                _context.Departures.Add(new Departure { Id = 1, PlaneId = plane.PlaneId, Time = time });
            }
            else _context.Departures.Add(new Departure { Id = _context.Departures.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1, PlaneId = plane.PlaneId, Time = time });
            _context.SaveChanges();
        }
    }
}

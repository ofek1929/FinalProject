using AirPort_Server.Hubs;
using Dal.Models;
using Dal.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class AirportLogic : IAirportLogic
    {
        private readonly IAirportStations _airportStations;
        private readonly IRepository _repository;
        private readonly ILanding _landing;
        private readonly IDeparture _departure;
        private readonly ITerminal _terminal;
        private readonly SendDataHub _hub;
        private  List<Plane> _landings = new List<Plane>();
        private  List<Plane> _departures = new List<Plane>();
        
        //private readonly List<ILanding> _landings = new List<ILanding>();

        public AirportLogic(IAirportStations airportStations, IRepository repository, ILanding landing, IDeparture departure, ITerminal terminal,SendDataHub hub)
        {
            _airportStations = airportStations;
            this._repository = repository;
            this._landing = landing;
            this._departure = departure;
            this._terminal = terminal;
            this._hub = hub;
        }


        public  void Start()
        {
            // asyc //await _hub.SendAllData(_repository.GetHistories(), GetDepartures(),Getlandings(),_repository.GetAllStations());
            //get data from db 
            //if (!_isStarted)
            //{
            //    _airportStations.AddStationsFromDb();
            //    _isStarted = true;
            //}
           
        }

        public void LandingComplete(Landing landing)
        {
            //the plane added to terminal

            //send a message to ui 


            //remove
            //_landings.Remove(landing);

        }
        public void LandingComplete(Plane plane)
        {
            //add the plane to terminal
            _terminal.AddPlaneToTerminal(plane);
            //add to db history 
            _repository.EnterTerminal("Terminal", plane, DateTime.Now);
            //delete the plane prom landings 
            _landings.Remove(plane);
            //_hub.SendLandings(Getlandings());
        }

        public void DepartureComplete(Plane plane)
        {
            //send a message that plane took off sucssesfully
            _departures.Remove(plane);
            //_hub.SendDepartments(GetDepartures());
        }



        //add to history and change station status 
        public void  AddToHistory(string id, Plane plane, DateTime time, bool isExit)
        {
            if (isExit)
            {
                _repository.ExitStation(id, plane, time);
            }
            else
            {
                _repository.EnterStation(id, plane, time);
            }
            //send to hub history and stations
             //_hub.SendStations(_repository.GetAllStations());
            // _hub.SendHistory(_repository.GetHistories());
        }

        public void  NewLanding(DateTime time)
        {
            //makes new plane with new id
            var plane = _repository.AddNewPlane(true);
            // add the new landing to db and  to list
            _landings.Add(plane);
            _repository.AddLanding(plane, DateTime.Now);
             //_hub.SendLandings(Getlandings());
            //call landing.land
            _landing.Land(plane, this);
            //add the landing to db landings

        }

        public void NewDeparting(DateTime time)
        {
            var plane = _repository.AddNewPlane(false);
            _departures.Add(plane);
            _repository.AddDeparture(plane, DateTime.Now);
            //send to hub departers
            //_hub.SendDepartments(GetDepartures());
            _terminal.AddPlaneToTerminal(plane);
            Thread.Sleep(5000);
            _terminal.RemovePlaneFromTerminal(plane);
            _departure.Departe(plane, this);
        }

        public List<Dal.Models.Departure> GetDepartures()
        {
            var t = _repository.GetDepartures();
            List<Dal.Models.Departure> dep = new List<Dal.Models.Departure>() ;
            foreach (var item in _departures)
            {
                dep.Add(t.FirstOrDefault(x => x.PlaneId == item.PlaneId));
            }
            return dep;
        }
        public List<Dal.Models.Landing> Getlandings()
        {
            var t = _repository.GetLandings();
            List<Dal.Models.Landing> lan = new List<Dal.Models.Landing>();
            foreach (var item in _landings)
            {
                lan.Add(t.FirstOrDefault(x => x.PlaneId == item.PlaneId));
            }
            return lan;
        }
    }
}

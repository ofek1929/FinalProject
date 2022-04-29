using Dal.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class AirportStations : IAirportStations
    {
        private List<IAirportStation> _stations = new List<IAirportStation>();
        Repository _repository;


        public AirportStations(IRepository repository)
        {
            _repository = repository as Repository;
            AddStationsFromDb();

        }


        public void AddStationsFromDb()
        {            
            foreach (var item in _repository.GetAllStations())
            {
                if (item.PlaneId != 0) _stations.Add(new AirportStation(item.StationName, _repository.GetPlane(item.PlaneId)));
                else _stations.Add(new AirportStation(item.StationName, null));
            }

        }



        public IAirportStation Get(string id)
        {
            if (_stations != null)
            {
                return _stations.Find(s => s.Id == id);
            }
            return null;
        }
    }
}

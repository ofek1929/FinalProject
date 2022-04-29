using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface IAirportStations
    {
        

        public void AddStationsFromDb();

        public IAirportStation Get(string id);


    }
}

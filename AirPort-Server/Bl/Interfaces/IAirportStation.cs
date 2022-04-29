using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface IAirportStation
    {
        public string Id { get; set; }
        public void ExitStation(IAirportLogic logic);
        public void EnterStation(Plane plane, IAirportLogic logic);
        public void Move(Plane plane, IAirportStation secondStation, IAirportLogic logic);
    }
}

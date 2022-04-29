using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface ILanding
    {
        public void Land(Plane plane , IAirportLogic logic);
    }
}

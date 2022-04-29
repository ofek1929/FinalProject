using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface ILandingRoute
    {
        public IList<IAirportStation> Stations { get; }
    }
}

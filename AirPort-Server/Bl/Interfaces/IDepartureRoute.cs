using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public interface IDepartureRoute
    {
        public IList<IAirportStation> Stations { get; }
    }
}

using Dal.Models;
using System.Collections.Generic;

namespace AirportServer.BL
{
    public interface ITerminal
    {
        
        public void AddPlaneToTerminal(Plane plane);
        public void RemovePlaneFromTerminal(Plane plane);
    }
}
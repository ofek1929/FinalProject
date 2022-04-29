using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class Terminal: ITerminal
    {
        public List<Plane> TerminalPlanes { get; private set; }
        public Terminal()
        {
            TerminalPlanes = new List<Plane>();
        }
        public void AddPlaneToTerminal(Plane plane)
        {
            TerminalPlanes.Add(plane);
            //add to db history
        }

        public void RemovePlaneFromTerminal(Plane plane)
        {
            TerminalPlanes.Remove(plane);
            // add timeout to history
        }
    
    }
}

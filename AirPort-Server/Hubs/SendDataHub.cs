using AirportServer.BL;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Models;

namespace AirPort_Server.Hubs
{
    public class SendDataHub: Hub
    {
        public async Task SendAllData(List<History> histories, List<Dal.Models.Departure> departures, List<Dal.Models.Landing> landings, List<Dal.Models.Station> stations)
        {
            await Clients.All.SendAsync("ReceiveAll", histories, departures, landings, stations);
        }    
        public async Task SendHistory(List<History> histories)
        {
            await Clients.All.SendAsync("ReceiveHistory", histories);
        }      
        public async Task SendDepartments(List<Dal.Models.Departure> departures)
        {
            await Clients.All.SendAsync("ReceiveDepartments", departures);
        }     
        public async void SendLandings(List<Dal.Models.Landing> landings)
        {
            await Clients.All.SendAsync("ReceiveLandings",landings);
        }     
        public async void SendStations(List<Dal.Models.Station> stations)
        {
           await Clients.All.SendAsync("ReceiveStations", stations);
        }

    }
}

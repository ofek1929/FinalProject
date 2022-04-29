using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AirportServer.BL
{
    public class AirportStation : IAirportStation
    {
        private object _key = new object();
        private Plane _plane;


        public string Id { get; set; }
        public static SemaphoreSlim semaphore67 = new SemaphoreSlim(2);
        public AirportStation(string id, Plane plane = null)
        {
            Id = id;
            _plane = plane;
        }
        public void EnterStation(Plane plane,IAirportLogic logic)
        {
            lock (_key)
            {
                logic.AddToHistory(Id, plane, DateTime.Now, false);
                _plane = plane;
                Console.WriteLine($"plane {_plane.PlaneId} is enter to station {Id}");
                Thread.Sleep(5000);
                ExitStation(logic);
            }
        }


        public void ExitStation(IAirportLogic logic)
        {
            Console.WriteLine($"plane {_plane.PlaneId} is exit to station {Id}");
            logic.AddToHistory(Id, _plane, DateTime.Now, true);
            _plane = null;
        }

        public void Move(Plane plane, IAirportStation secondStation , IAirportLogic logic)
        {
            semaphore67.Wait();
            try
            {
                //if in the station there is null put the plane in the station
                //but if there is a plane so the if will be true and
               
                
                if (null != Interlocked.CompareExchange(ref _plane, plane, null))
                {
                    //move to station 7
                    secondStation.EnterStation(plane,logic);
                    secondStation.ExitStation(logic);
                }
                else
                {
                    Console.WriteLine($"plane {_plane.PlaneId} is enter to station {Id}");
                    logic.AddToHistory(Id, plane, DateTime.Now, false);
                    Thread.Sleep(5000);
                    this.ExitStation(logic);
                }
                //if (plane != null)
                //{
                //    //move to station 7
                //    secondStation.EnterStation(plane);
                //    secondStation.ExitStation();
                //}
                //else
                //{
                //    _plane = plane;
                //    Thread.Sleep(5000);
                //    ExitStation();
                //}

            }
            finally
            {
                semaphore67.Release();
            }
        }
    }


}
//if (_plane != null)//put in whating list 
//{
//    _wheitingList.Add(plane);


//}
//else
//{
//    _plane = plane;
////}
//private void EnterWhitingPlane()
//{
//    lock (_key)
//    {
//        //put the wheting plan in the station and delete from the list               
//        _plane = _wheitingList[0];
//        _wheitingList.RemoveAt(0);
//        //save to the db history 
//        //sand changes to ui 
//    }
//}
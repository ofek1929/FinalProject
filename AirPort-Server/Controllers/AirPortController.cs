using AirportServer.BL;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using System.Timers;

namespace AirPort_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
   // [Route("api/[controller]")]
    public class AirPortController : Controller
    {
        private readonly IAirportLogic _logic;
        //ILogger<WeatherForecastController> logger
        //private readonly ILogger<AirPortController> _logger;
        static Timer timer;
        public AirPortController(IAirportLogic logic)//ilogic
        {
            this._logic = logic;
            timer = new Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        private  void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random();
            if (rnd.Next(2) == 1)
            {
                Console.WriteLine("timer elapsed add new landing");
                _logic.NewLanding(DateTime.Now);
            }
            else
            {
                Console.WriteLine("timer elapsed add new depature");
                _logic.NewDeparting(DateTime.Now);
            }
            //Console.WriteLine("timer elapsed add new landing");
            //timer.Elapsed -= Timer_Elapsed;
            //_logic.NewLanding(DateTime.Now);

        }
        //public string Index()
        //{
        //    //Console.WriteLine("index controller in");

        //    //_logic.Start();
        //    return "";
        //}

        [HttpGet]
        public string Start()
        {
            Console.WriteLine("stat controller in");
            _logic.Start();
            return "";
        }

        [HttpPost]
        [Route("landing")]
        public void AddLanding()
        {
            //the simulator call this controller in http post
            
            _logic.NewLanding(DateTime.Now);
            
        }
        [HttpPost]
        [Route("TakeOff")]
        public void AddDeparture()
        {
            _logic.NewDeparting(DateTime.Now);
        }
    }
}

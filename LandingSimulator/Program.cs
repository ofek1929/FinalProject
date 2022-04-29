using System;
using System.Net.Http;
using System.Timers;

namespace LandingSimulator
{
    class Program
    {
        static HttpClient httpClient;
        static Timer timer;
        static void Main(string[] args)
        {
            httpClient = new HttpClient();
            //var resp = httpClient.GetStringAsync("https://localhost:44367/").Result;
            //var resp = httpClient.GetStringAsync("https://localhost:5001/").Result;
            var resp = httpClient.GetStringAsync("http://localhost:5000/airport/landing").Result;
           Console.WriteLine($"Strting simulator {resp}");

            

            timer = new Timer(5000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           // httpClient.GetStringAsync("http://localhost:5000/landing");
            httpClient.GetStringAsync("http://localhost:5000/api/airport/landing");
            
        }
    }
}

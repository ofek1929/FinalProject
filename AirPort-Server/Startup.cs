using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using AirportServer.BL;
using Dal.Repositorys;
using System.Threading;
using AirPort_Server.Hubs;

namespace AirPort_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();
            services.AddSingleton<IAirportLogic, AirportLogic>();
            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<IAirportStations, AirportStations>();
            services.AddSingleton<ILanding, Landing>();
            services.AddSingleton<IDeparture, Departure>();
            services.AddSingleton<ITerminal, Terminal>();
            services.AddSingleton<ILandingRoute, LandingRoute>();
            services.AddSingleton<IDepartureRoute,DepartingRoute>();
            services.AddSingleton<SendDataHub>();
         



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                
                endpoints.MapHub<SendDataHub>("/data");
            });
        }
    }
}

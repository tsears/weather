using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using tsears.Weather.Services.Geo;
using tsears.Weather.Services.Weather;
using tsears.Weather.Services;

namespace tsears.Weather
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
            var geoRestSvc = new RestRequestor<GeoResponse>();
            var weatherRestSvc = new RestRequestor<ForecastResponse>();
            var parser = new GeoQueryParser();
            var geoDispatchSvc = new GeocodioQueryDispatchService(geoRestSvc);
            var weatherDispatchSvc = new DarkskyQueryDispatchService(weatherRestSvc);
            
            services.AddMvc();

            services.AddSingleton<IGeoQueryService>(new GeocodioQueryService(parser, geoDispatchSvc));
            services.AddSingleton<IWeatherQueryService>(new DarkskyQueryService(weatherDispatchSvc));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug();
            }
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseMvc();
        }
    }
}

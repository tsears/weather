using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace tsears.Weather
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            
            if (Environment.GetEnvironmentVariable("DARKSKY_API_KEY") == null) {
              throw new Exception("Missing weather API key");
            }
            
            if (Environment.GetEnvironmentVariable("GEOCODIO_API_KEY") == null) {
                throw new Exception("Missing geo API key");
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}

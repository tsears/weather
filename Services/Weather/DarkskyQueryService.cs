using tsears.Weather.Services.Geo;
using System.Text;
using System;
using System.Threading.Tasks;
using tsears.Weather.DataStructures;

namespace tsears.Weather.Services.Weather
{
    public class DarkskyQueryService: IWeatherQueryService
    {
        private readonly IWeatherQueryDispatchService _weatherQueryDispatchService;

        public DarkskyQueryService(IWeatherQueryDispatchService weatherQueryDispatchService) {
            _weatherQueryDispatchService = weatherQueryDispatchService;
        }

        public async Task<IForecastResponse> Query(GeoCoordinate coord) {

            var cacheKey = $"{coord.Lat},{coord.Long}";

            var sb = new StringBuilder("https://api.darksky.net/forecast/");
    
            sb.Append(Environment.GetEnvironmentVariable("DARKSKY_API_KEY"));
            sb.Append($"/{coord.Lat},{coord.Long}");

            var query = sb.ToString();

            var forecast = await _weatherQueryDispatchService.Query(query).ConfigureAwait(false);
            return forecast;
        }
    }
}
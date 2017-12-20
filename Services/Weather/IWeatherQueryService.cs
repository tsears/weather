using tsears.Weather.DataStructures;
using tsears.Weather.Services.Weather;
using System.Threading.Tasks;

namespace tsears.Weather.Services.Weather
{
  public interface IWeatherQueryService
  {
    Task<IForecastResponse> Query(GeoCoordinate coord);
  }
}

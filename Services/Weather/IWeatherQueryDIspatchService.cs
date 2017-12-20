using tsears.Weather.DataStructures;
using System.Threading.Tasks;

namespace tsears.Weather.Services.Weather
{
  public interface IWeatherQueryDispatchService
  {
    Task<IForecastResponse> Query(string query);
  }
}

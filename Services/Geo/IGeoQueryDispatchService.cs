using System.Threading.Tasks;

namespace tsears.Weather.Services.Geo
{
    public interface IGeoQueryDispatchService{
    Task<GeoResponse> Query(string query);
  }
}

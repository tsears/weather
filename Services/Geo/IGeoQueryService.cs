using System.Threading.Tasks;
using tsears.Weather.DataStructures;

namespace tsears.Weather.Services.Geo
{
    public interface IGeoQueryService
  {
    Task<GeoResponse> Query(string query);
    Task<GeoResponse> ReverseQuery(GeoCoordinate geo);
  }
}

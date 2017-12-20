using System.Net;
using System.Runtime.Serialization.Json;
using tsears.Weather.DataStructures;
using System.Threading.Tasks;

namespace tsears.Weather.Services.Weather {

    public class DarkskyQueryDispatchService : IWeatherQueryDispatchService
    {
        private readonly RestRequestor<ForecastResponse> _restService;

        public DarkskyQueryDispatchService(RestRequestor<ForecastResponse> restService) {
            _restService = restService;
        }

        public async Task<IForecastResponse> Query(string q) {
            ForecastResponse resp = await _restService.MakeRequest(q).ConfigureAwait(false);
            return resp;
        }
    }
}
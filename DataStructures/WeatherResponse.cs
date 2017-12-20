using tsears.Weather.Services.Geo;
using tsears.Weather.Services.Weather;

namespace tsears.Weather.DataStructures {
    public class WeatherResponse {
        private GeoResponse _geo;
        private IForecastResponse _weather;
        public WeatherResponse(GeoResponse geo, IForecastResponse weather) {
            this._geo = geo;
            this._weather = weather;
        }

        public GeoResponse Geo
        {
            get { return _geo; }
        }

        public IForecastResponse Weather
        {
            get { return _weather; }
        }
    }
}
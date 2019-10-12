using Newtonsoft.Json;

namespace WeatherConsole.Core.Contracts
{
    public class CityWeather
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("precipitation")]
        public int Precipitation { get; set; }

        [JsonProperty("weather")]
        public string Weather { get; set; }
    }
}

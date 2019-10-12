using Newtonsoft.Json;

namespace WeatherConsole.Core.Contracts
{
    public class ApiToken
    {
        [JsonProperty("bearer")]
        public string Token { get; set; }
    }
}

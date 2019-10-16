using System.Threading.Tasks;
using WeatherConsole.Core.Weather;
using WeatherConsole.Infrastructure.Api;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application.Weather
{
    public class CityWeatherService : IWeatherService
    {
        private readonly ApiClient _apiClient;

        public CityWeatherService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<ITerritory> GetTerritory(Command command)
        {
            var weather = await _apiClient.GetCityWeather(command.Value);
            return new City(command.Value, weather);
        }

        public async Task<string> GetAvailableTerritories()
        {
            return await _apiClient.GetCities();
        }
    }
}

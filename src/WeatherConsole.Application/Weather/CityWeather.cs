using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherConsole.Infrastructure.Api;

namespace WeatherConsole.Application.Weather
{
    public class CityWeather
    {
        private readonly ApiClient _apiClient;

        public CityWeather(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task DisplayWeather(string selectedCity)
        {
            Console.WriteLine("Sending request...");
            var weatherStats = await _apiClient.GetCityWeather(selectedCity);
            Console.WriteLine($"Displaying weather statistics of {selectedCity}: ");
            Console.WriteLine($"    Weather status is {weatherStats.Weather}\r\n" +
                $"    Temperature is {weatherStats.Temperature}\r\n" +
                $"    Precipitation is {weatherStats.Precipitation}\r\n");
        }
    }
}

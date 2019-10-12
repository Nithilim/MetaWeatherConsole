using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherConsole.Infrastructure.Api;

namespace WeatherConsole.Application.Weather
{
    public class AvailableCities
    {
        private readonly ApiClient _apiClient;
        
        public AvailableCities(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task DisplayCities()
        {
            Console.WriteLine("Loading...");
            string cities = await _apiClient.GetCities();
            Console.WriteLine($"Available Cities: {FormatCities(cities)} \r\n");
        }

        private string FormatCities(string cities)
        {
            var charsToRemove = new string[] { "[", "]", "\"" };
            foreach (var c in charsToRemove)
            {
                cities = cities.Replace(c, string.Empty);
            }
            return cities;
        }
    }
}

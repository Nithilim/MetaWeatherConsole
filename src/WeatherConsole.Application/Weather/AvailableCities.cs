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
            string cities = await _apiClient.GetCities();
            Console.WriteLine($"");
        }

        private string[] FormatCities(string cities)
        {
            return cities.Trim().Split();
        }
    }
}

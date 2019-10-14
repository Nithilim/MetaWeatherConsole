using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherConsole.Core.Contracts;
using Newtonsoft.Json;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Infrastructure.Api
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new HttpClient(new TokenHandler(baseUrl));
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<string> GetCities()
        {
            var response = await _client.GetAsync("/api/cities");
            if (!response.IsSuccessStatusCode)
                throw new ApiException("API request was not successful!");

            string cities = await response.Content.ReadAsStringAsync();
            EnsureContentReturned(cities);
            return cities;
        }

        public async Task<CityWeather> GetCityWeather(string cityName)
        {
            var response = await _client.GetAsync($"/api/Weather/{cityName}");
            if (!response.IsSuccessStatusCode)
                throw new ApiException("API request was not successful!");

            string stream = await response.Content.ReadAsStringAsync();
            var cityWeather = JsonConvert.DeserializeObject<CityWeather>(stream);
            EnsureContentReturned(cityWeather?.CityName);
            return cityWeather;
        }

        private void EnsureContentReturned<T>(T content)
        {
            if(content == null)
                throw new ApiException("API Response content is empty");
        }
    }
}

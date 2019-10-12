using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherConsole.Core.Contracts;
using Newtonsoft.Json;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Infrastructure.Api
{
    public class ApiClient
    {
        private readonly HttpClient _client;
        private ApiToken _token;

        public ApiClient(string baseUrl)
        {
            _client = new HttpClient(new TokenHandler(baseUrl));
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<string> GetCities()
        {
            var response = await _client.GetAsync("/api/cities");
            return await response.Content.ReadAsStringAsync();
        }
    }
}

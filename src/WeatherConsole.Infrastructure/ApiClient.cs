using System;
using System.Collections.Generic;
using System.Net.Http;

namespace WeatherConsole.Infrastructure
{
    public class ApiClient
    {
        private HttpClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }
    }
}

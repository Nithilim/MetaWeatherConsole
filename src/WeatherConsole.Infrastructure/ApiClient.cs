using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherConsole.Core.Contracts;
using Newtonsoft.Json;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Infrastructure
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(string baseUrl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
        }

        public async Task<ApiToken> Authorize(string username, string password)
        {
            var cancellationToken = new CancellationTokenSource();
            var response = await _client.PostAsync("/api/authorize", new JsonContent(new Dictionary<string, string>
            {
                { "username", username },
                {"password", password }
            }), cancellationToken.Token);

            if (!response.IsSuccessStatusCode)
                throw new ApiException("Response status was not successful");

            string stream = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<ApiToken>(stream);
            if (token == null || string.IsNullOrEmpty(token.Token))
                throw new ApiException("Response content is empty");

            return token;
        }


    }
}

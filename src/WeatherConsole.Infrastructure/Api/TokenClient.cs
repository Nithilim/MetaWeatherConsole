using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherConsole.Core.Contracts;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Infrastructure.Api
{
    public class TokenClient
    {
        private readonly HttpClient _client;

        public TokenClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiToken> Authorize(string username, string password, CancellationToken cancellationToken = default)
        {
            var response = await _client.PostAsync("/api/authorize", new JsonContent(new Dictionary<string, string>
            {
                { "username", username },
                {"password", password }
            }), cancellationToken);

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

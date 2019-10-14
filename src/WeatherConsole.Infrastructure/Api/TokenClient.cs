using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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

        public async Task<ApiToken> Authorize(CancellationToken cancellationToken = default)
        {
            var response = await _client.PostAsync("/api/authorize", new JsonContent(new Dictionary<string, string>
            {
                { "username", "meta" },
                {"password", "site" }
            }), cancellationToken);

            if (!response.IsSuccessStatusCode)
                throw new ApiException("API request was not successful");

            string stream = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<ApiToken>(stream);
            if (token == null || string.IsNullOrEmpty(token.Token))
                throw new ApiException("API Response content is empty");

            return token;
        }
    }
}

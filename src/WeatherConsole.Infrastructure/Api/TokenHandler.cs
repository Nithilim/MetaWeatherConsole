using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using WeatherConsole.Core.Contracts;

namespace WeatherConsole.Infrastructure.Api
{
    public class TokenHandler : DelegatingHandler
    {
        public readonly TokenClient _tokenClient;
        private ApiToken _token;

        public TokenHandler(string baseUrl)
        {
            _tokenClient = new TokenClient(new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            });
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (_token == null)
                _token = await _tokenClient.Authorize();

            SetAuthHeader(request);
            var response = await base.SendAsync(request, cancellationToken);
            if(response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _token = await _tokenClient.Authorize();
                SetAuthHeader(request);
                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }

        private void SetAuthHeader(HttpRequestMessage request) 
            => request.Headers.Authorization = new AuthenticationHeaderValue("bearer", _token.Token);
    }
}

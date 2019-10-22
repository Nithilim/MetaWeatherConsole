using Xunit;
using WeatherConsole.Application.Weather;
using WeatherConsole.Infrastructure.Api;
using WeatherConsole.Core.Commands;
using System.Threading.Tasks;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Application.Test
{
    public class CityWeatherServiceTest
    {
        [Fact]
        public async Task NullArgsThrowsApiException()
        {
            var sut = CreateSut();
            await Assert.ThrowsAsync<ApiException>(() => sut.GetCityWeather(null));
        }

        [Fact]
        public async Task StringWithNoValueThrowsApiException()
        {
            var sut = CreateSut();
            await Assert.ThrowsAsync<ApiException>(() => sut.GetCityWeather(""));
        }

        [Fact]
        public async Task StringWithInvalidValueThrowsApiException()
        {
            var sut = CreateSut();
            await Assert.ThrowsAsync<ApiException>(() => sut.GetCityWeather("asdasgfqwe"));
        }

        [Fact]
        public async Task StringWithValidValueReturnsTerritory()
        {
            var sut = CreateSut();
            var result = await sut.GetCityWeather("Vilnius");
            Assert.Equal("Vilnius", result.CityName);
        }

        private ApiClient CreateSut() => new ApiClient("https://metasite-weather-api.herokuapp.com/");
    }
}

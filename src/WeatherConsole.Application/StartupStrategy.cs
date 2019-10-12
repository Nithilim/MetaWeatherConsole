using System;
using System.Collections.Generic;
using System.Text;
using WeatherConsole.Infrastructure;
using WeatherConsole.Infrastructure.Api;

namespace WeatherConsole.Application
{
    public class StartupStrategy
    {
        public async void Initialize()
        {
            var client = new ApiClient("https://metasite-weather-api.herokuapp.com/");
            string list = await client.GetCities();
        }
    }
}

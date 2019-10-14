using System;
using WeatherConsole.Core.Contracts;
using WeatherConsole.Core.Weather;

namespace WeatherConsole.Application.Weather
{
    public class City : ICity
    {
        public string Name { get; }

        private readonly CityWeather _weather;

        public City(string name, CityWeather weather)
        {
            Name = name;
            _weather = weather;
        }

        public void DisplayWeather()
        {
            Console.WriteLine($"Displaying weather statistics of {Name}: ");
            Console.WriteLine($"    Weather status is {_weather.Weather}\r\n" +
                $"    Temperature is {_weather.Temperature}\r\n" +
                $"    Precipitation is {_weather.Precipitation}\r\n");
        }
    }
}

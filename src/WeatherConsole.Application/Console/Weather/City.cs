﻿using System;
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
            Console.WriteLine($"    Weather status: {_weather.Weather}\r\n" +
                $"    Temperature: {_weather.Temperature}\r\n" +
                $"    Precipitation: {_weather.Precipitation}\r\n");
        }
    }
}
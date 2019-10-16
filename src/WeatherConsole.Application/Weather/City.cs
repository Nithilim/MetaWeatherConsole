using WeatherConsole.Core.Contracts;
using WeatherConsole.Core.Weather;

namespace WeatherConsole.Application.Weather
{
    public class City : ITerritory
    {
        public string Name { get; }

        public WeatherStatistics WeatherStatistics { get; }

        public City(string name, WeatherStatistics weatherStatistics)
        {
            Name = name;
            WeatherStatistics = weatherStatistics;
        }
    }
}

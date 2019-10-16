using WeatherConsole.Core.Contracts;

namespace WeatherConsole.Core.Weather
{
    public interface ITerritory
    {
        string Name { get; }

        WeatherStatistics WeatherStatistics { get; }
    }
}
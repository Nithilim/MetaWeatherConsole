using System;
using WeatherConsole.Core.Weather;

namespace WeatherConsole.Application.Weather
{
    public class WeatherConsoleMessenger
    {
        public void ShowGuidelines()
        {
            Console.WriteLine("Command example: \"weather --city City Name1\" or \"weather -c City Name\"");
            Console.WriteLine("You can chain multiple cities: \"weather --city City Name1, City Name2\"");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAvailableTerritories(string territories)
        {
            Console.WriteLine($"Available Cities: {FormatCities(territories)} \r\n");
        }

        public void ShowTerritoryWeather(ITerritory territory)
        {
            Console.WriteLine($"Displaying weather statistics of {territory.Name}: ");
            Console.WriteLine($"    Weather status: {territory.WeatherStatistics.Weather}\r\n" +
                $"    Temperature: {territory.WeatherStatistics.Temperature}\r\n" +
                $"    Precipitation: {territory.WeatherStatistics.Precipitation}\r\n");
        }

        private string FormatCities(string city)
        {
            var charsToRemove = new string[] { "[", "]", "\"" };
            foreach (var c in charsToRemove)
                city = city.Replace(c, string.Empty);

            return city;
        }
    }
}

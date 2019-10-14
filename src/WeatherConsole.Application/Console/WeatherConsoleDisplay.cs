using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherConsole.Core.Weather;
using WeatherConsole.Infrastructure.Api;

namespace WeatherConsole.Application.Weather
{
    public class WeatherConsoleDisplay
    {
        private readonly ApiClient _apiClient;
        public WeatherConsoleDisplay(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Run(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                await ShowGuidelines();
                var cities = await PrepareCityWeathers(PrepareCommands(args));  
                bool validChoice = false;
                Console.WriteLine("Run again? (y/n)");
                while (!validChoice)
                {
                    string userChoice = Console.ReadLine();
                    if (userChoice == "y" || userChoice == "Y")
                        validChoice = true;
                    else if (userChoice == "n" || userChoice == "N")
                    {
                        validChoice = true;
                        exit = true;
                    }
                    else
                        Console.WriteLine("Wrong entry!");
                }
            }
        }

        private async Task<IEnumerable<ICity>> PrepareCityWeathers(IEnumerable<Command> commands)
        {
            var cities = new List<City>();
            foreach(var command in commands)
            {
                var weather = await _apiClient.GetCityWeather(command.Value);
                cities.Add(new City(command.Value, weather));
            }

            return cities;
        }

        private async Task ShowGuidelines()
        {
            Console.WriteLine("Checking available cities...");
            string availableCities = await _apiClient.GetCities();
            Console.WriteLine($"Available Cities: {FormatCities(availableCities)} \r\n");
            Console.WriteLine("Please enter command \"--city City Name\" or \"-c City Name\" : ");
        }

        private IEnumerable<Command> PrepareCommands(string[] args)
        {
            string command = "";
            if (!args.Any())
            {
                command = Console.ReadLine();
                bool validComand = ArgsParser.IsCommandValid(command);
                while (!validComand)
                {
                    Console.WriteLine("Wrong entry! Try again: ");
                    command = Console.ReadLine();
                    validComand = ArgsParser.IsCommandValid(command);
                } 
            }
            else
                command = args[0];

            return ArgsParser.ParseCommand(command);
        }

        private string FormatCities(string cities)
        {
            var charsToRemove = new string[] { "[", "]", "\"" };
            foreach (var c in charsToRemove)
            {
                cities = cities.Replace(c, string.Empty);
            }
            return cities;
        }
    }
}

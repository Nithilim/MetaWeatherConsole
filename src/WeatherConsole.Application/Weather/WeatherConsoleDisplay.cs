using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application.Weather
{
    public class WeatherConsoleDisplay
    {
        private readonly AvailableCities _cities;
        private readonly CityWeather _cityWeather;

        public WeatherConsoleDisplay(AvailableCities cities, CityWeather cityWeather)
        {
            _cities = cities;
            _cityWeather = cityWeather;
        }

        public async Task InitializeConsole(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                var commands = await PrepareCommands(args);
                foreach (var command in commands)
                    await _cityWeather.DisplayWeather(command.Value);

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

        private async Task<IEnumerable<Command>> PrepareCommands(string[] args)
        {
            string command = "";
            if (!args.Any())
            {
                await _cities.DisplayCities();
                Console.WriteLine("Please enter command \"--city City Name\" or \"-c City Name\" : ");
                command = Console.ReadLine();
            }
            else
                command = args[0];

            return ArgsParser.ParseCommand(command);
        }
    }
}

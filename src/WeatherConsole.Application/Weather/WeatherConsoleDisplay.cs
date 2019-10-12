using System;
using System.Collections.Generic;
using System.Linq;
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

        public void InitializeConsole(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                PrepareCommands(args);

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

        private IEnumerable<Command> PrepareCommands(string[] args)
        {
            string command = "";
            if (!args.Any())
            {
                Console.WriteLine("Please enter command: ");
                command = Console.ReadLine();
            }
            else
                command = args[0];

            return ArgsParser.ParseCommand(command);
        }
    }
}

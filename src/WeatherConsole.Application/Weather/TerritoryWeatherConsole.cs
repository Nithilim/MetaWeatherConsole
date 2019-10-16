using System.Linq;
using System.Collections.Generic;
using WeatherConsole.Application.CommandParsers;
using WeatherConsole.Core.Commands;
using System.Threading.Tasks;
using WeatherConsole.Core.Weather;
using WeatherConsole.Infrastructure.Exceptions;

namespace WeatherConsole.Application.Weather
{
    public class TerritoryWeatherConsole
    {
        private readonly IWeatherService _cityWeatherService;
        private readonly WeatherConsoleMessenger _messenger;
        private readonly CommandParser _parser;

        public TerritoryWeatherConsole(IWeatherService cityWeatherService,
            WeatherConsoleMessenger messenger,
            CommandParser parser)
        {
            _cityWeatherService = cityWeatherService;
            _messenger = messenger;
            _parser = parser;
        }

        public async Task Run(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                var commands = new List<Command>();
                if (args.Any())
                {
                    foreach (string arg in args)
                        commands.AddRange(_parser.ParseCommand(arg));
                    args = new string[] { };
                }
                else
                {
                    await ShowNoArgsFlow();
                    commands.AddRange(_parser.ParseCommand(_parser.ParseInput()));
                }

                if (commands.Any())
                {
                    await ShowTerritoriesWeather(commands);
                }
                else
                    _messenger.ShowMessage("Wrong command entered.");

                exit = !RunAgain();
            }
        }

        private async Task ShowNoArgsFlow()
        {
            try
            {
                _messenger.ShowMessage("Checking available territories...");
                _messenger.ShowAvailableTerritories(await _cityWeatherService.GetAvailableTerritories());
                _messenger.ShowGuidelines();
                _messenger.ShowMessage("Please enter command: ");
            }
            catch(ApiException ex)
            {
                _messenger.ShowMessage(ex.Message);
            }
            
        }

        private async Task ShowTerritoriesWeather(IEnumerable<Command> commands)
        {
            try
            {
                var territories = new List<ITerritory>();
                foreach (var command in commands)
                {
                    if (command.Type == CommandType.City)
                        territories.Add(await _cityWeatherService.GetTerritory(command));
                }
                foreach (var territory in territories)
                    _messenger.ShowTerritoryWeather(territory);
            }
            catch(ApiException ex)
            {
                _messenger.ShowMessage(ex.Message);
            }
        }

        private bool RunAgain(bool recursion = false)
        {
            if (recursion == true)
                _messenger.ShowMessage("Wrong entry.");

            _messenger.ShowMessage("Run again? (y/n)");
            string userChoice = _parser.ParseInput();
            if (userChoice == "y" || userChoice == "Y")
                return true;

            else if (userChoice == "n" || userChoice == "N")
                return false;

            else
                return RunAgain(true);
        }
    }
}

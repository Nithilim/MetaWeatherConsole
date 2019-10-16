using System.Threading.Tasks;
using WeatherConsole.Core.Commands;
using WeatherConsole.Core.Weather;

namespace WeatherConsole.Application.Weather
{
    public interface IWeatherService
    {
        Task<ITerritory> GetTerritory(Command command);

        Task<string> GetAvailableTerritories();
    }
}

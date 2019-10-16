using Autofac;
using WeatherConsole.Application.IoCContainer;
using WeatherConsole.Application.Weather;

namespace WeatherConsole.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfiguration.ConfigureContainer();
            using(var scope = container.BeginLifetimeScope())
            {
                var weatherConsole = scope.Resolve<TerritoryWeatherConsole>();
                weatherConsole.Run(args).GetAwaiter().GetResult();
            }
        }
    }
}

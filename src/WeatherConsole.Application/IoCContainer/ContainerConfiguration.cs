using Autofac;
using WeatherConsole.Application.CommandParsers;
using WeatherConsole.Application.Weather;
using WeatherConsole.Infrastructure.Api;

namespace WeatherConsole.Application.IoCContainer
{
    public static class ContainerConfiguration
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new ApiClient("https://metasite-weather-api.herokuapp.com/"));
            builder.RegisterType<CityWeatherService>().Named<IWeatherService>("cityWeatherService").SingleInstance();
            builder.RegisterType<WeatherConsoleMessenger>().SingleInstance();
            builder.RegisterType<CommandParser>().SingleInstance();
            builder.Register(c => new TerritoryWeatherConsole(
                c.ResolveNamed<IWeatherService>("cityWeatherService"),
                c.Resolve<WeatherConsoleMessenger>(),
                c.Resolve<CommandParser>()))
                .SingleInstance();

            return builder.Build();
        }
    }
}

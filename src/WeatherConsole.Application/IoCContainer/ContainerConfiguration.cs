using Autofac;
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
            builder.RegisterType<WeatherConsoleDisplay>();

            return builder.Build();
        }
    }
}

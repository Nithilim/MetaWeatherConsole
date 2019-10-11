using Autofac;
using WeatherConsole.Infrastructure;

namespace WeatherConsole.Application.IoCContainer
{
    public static class ContainerConfiguration
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new ApiClient("https://metasite-weather-api.herokuapp.com/"));
        }
    }
}

using Autofac;

namespace WeatherConsole.Application.IoCContainer
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            return builder.Build();
        }
    }
}

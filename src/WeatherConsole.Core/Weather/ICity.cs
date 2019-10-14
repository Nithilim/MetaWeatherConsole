namespace WeatherConsole.Core.Weather
{
    public interface ICity
    {
        string Name { get; }

        void DisplayWeather();
    }
}
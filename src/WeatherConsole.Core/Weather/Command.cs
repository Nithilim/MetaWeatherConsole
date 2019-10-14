namespace WeatherConsole.Core.Weather
{
    public class Command
    {
        public string Type { get; set; }

        public string Value { get; }

        public Command(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
namespace WeatherConsole.Core.Commands
{
    public class Command
    {
        public CommandType Type { get; set; }

        public string Value { get; }

        public Command(CommandType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
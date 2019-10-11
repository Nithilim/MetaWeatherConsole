namespace WeatherConsole.Core.Commands
{
    public class CityCommand : Command
    {
        public CommandType Type => CommandType.City;

        public CityCommand(string value) : base(value)
        {
        }
    }
}

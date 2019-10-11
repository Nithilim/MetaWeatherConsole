using System.Collections.Generic;
using System.Linq;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application
{
    public class ArgsParser
    {
        public static IEnumerable<Command> ParseCommand(string args)
        {
            string command = "";
            if(args != string.Empty)
            {
                if (args.StartsWith("--city"))
                    command = "--city";

                else if(args.StartsWith("-c") && !args.StartsWith("-city"))
                    command = "-c";

                args = args.Remove(0, command.Length);
            }

            if (command == "--city" || command == "-c")
            {
                var commandValues = args.Split(',').ToList();
                var commands = commandValues.Select(i => new CityCommand(i.Trim()));
                return commands;
            }

            return new List<Command>();
        }
    }
}

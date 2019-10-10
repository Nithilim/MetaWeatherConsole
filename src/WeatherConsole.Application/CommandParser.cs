using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherConsole.Application
{
    public class CommandParser
    {
        public static IEnumerable<Command> ParseCommand(string args)
        {
            string command = "";
            if(args != string.Empty)
            {
                if (args.StartsWith("--city"))
                    command = "--city";

                if(args.StartsWith("-c") && !args.StartsWith("-city"))
                    command = "-c";

                args.Remove(0, command.Length);
            }

            if (args.Contains("--city"))
            {
                var commandValues = args.Split(',').ToList();
                var commands = commandValues.Select(i => new CityCommand(i));
                return commands;
            }

            return new List<Command>();
        }
    }
}

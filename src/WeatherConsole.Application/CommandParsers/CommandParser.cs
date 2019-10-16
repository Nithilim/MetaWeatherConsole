using System.Collections.Generic;
using System.Linq;
using System;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application.CommandParsers
{
    public class CommandParser
    {
        public IEnumerable<Command> ParseCommand(string args)
        {
            if(IsArgsValid(args))
            {
                var commandEndIndex = args.IndexOf(" ");
                if (commandEndIndex > 0)
                {
                    var command = args.Substring(0, args.IndexOf(" "));
                    if (command == "-c" || command == "--city")
                    {
                        string values = args.Remove(0, command.Length);
                        var splitValues = values.Split(',');
                        return splitValues.Select(v => new Command(CommandType.City, v.Trim()));
                    }
                }
            }

            return new List<Command>();
        }

        public string ParseInput()
        {
            return Console.ReadLine();
        }

        private bool IsArgsValid(string args)
        {
            if (args == null || string.IsNullOrEmpty(args))
                return false;

            return true;
        }
    }
}

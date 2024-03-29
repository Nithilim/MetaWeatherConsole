﻿using System.Collections.Generic;
using System.Linq;
using System;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application.CommandParsers
{
    public class CommandParser
    {
        public IEnumerable<Command> ParseCommand(string args)
        {
            if (IsArgsValid(args))
            {
                if (args.StartsWith("weather") || args.StartsWith("Weather"))
                    args = args.Remove(0, "weather".Length + 1);

                var commandEndIndex = args.IndexOf(" ");
                if (commandEndIndex > 0)
                {
                    var command = args.Substring(0, args.IndexOf(" "));
                    if (command == "-c" || command == "--city")
                    {
                        string values = args.Remove(0, command.Length).Trim();
                        if (IsArgsValid(values))
                        {
                            var splitValues = values.Split(',');
                            return splitValues.Select(v => new Command(CommandType.City, v));
                        }
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
            if (string.IsNullOrEmpty(args))
                return false;

            return true;
        }
    }
}

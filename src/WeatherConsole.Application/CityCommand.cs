using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConsole.Application
{
    public class CityCommand : Command
    {
        public CommandType Type => CommandType.City;

        public CityCommand(string value) : base(value)
        {
        }
    }
}

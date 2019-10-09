using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConsole.Application
{
    public class Command
    {
        public string Value { get; }

        public Command(string value)
        {
            Value = value;
        }
    }
}

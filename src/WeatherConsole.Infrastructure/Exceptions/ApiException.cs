using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConsole.Infrastructure.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }
    }
}

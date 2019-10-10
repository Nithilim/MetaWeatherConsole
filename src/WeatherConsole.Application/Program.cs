using System;
using System.Collections.Generic;

namespace WeatherConsole.Application
{
    class Program
    {
        static void Main(string args)
        {
            while(Keyboard.)
            Console.WriteLine("Press ESC to exit");
            PrepareCommands(args);
        }

        private static IEnumerable<Command> PrepareCommands(string args)
        {
            if (string.IsNullOrEmpty(args))
            {
                Console.WriteLine("Please enter command: ");
                args = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using WeatherConsole.Core.Commands;
using WeatherConsole.Infrastructure;

namespace WeatherConsole.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var startup = new StartupStrategy();
            startup.Initialize();
            bool exit = false; 
            while(!exit)
            {
                PrepareCommands(args);

                bool validChoice = false;
                Console.WriteLine("Run again? (y/n)");
                while (!validChoice)
                {
                    string userChoice = Console.ReadLine();
                    if (userChoice == "y" || userChoice == "Y")
                        validChoice = true;
                    else if(userChoice == "n" || userChoice == "N")
                    {
                        validChoice = true;
                        exit = true;
                    }
                    else
                        Console.WriteLine("Wrong entry!");
                }
            }
        }

        private static IEnumerable<Command> PrepareCommands(string[] args)
        {
            string command = "";
            if (!args.Any())
            {
                Console.WriteLine("Please enter command: ");
                command = Console.ReadLine();
            }
            else
                command = args[0];

            return ArgsParser.ParseCommand(command);
        }
    }
}

using System.Linq;
using Xunit;
using WeatherConsole.Application.CommandParsers;
using WeatherConsole.Core.Commands;

namespace WeatherConsole.Application.Test
{
    public class CommandParserTest
    {
        [Fact]
        public void UsingCorrectArgsSucceeds()
        {
            var sut = new CommandParser();
            Assert.True(sut.ParseCommand("-c Vilnius").Any());
            Assert.True(sut.ParseCommand("--city Vilnius").Any());
        }

        [Fact]
        public void ParserReturnsCommandWithValue()
        {
            var sut = new CommandParser();
            var command = sut.ParseCommand("-c Vilnius").FirstOrDefault();
            Assert.Equal("Vilnius", command.Value);
            Assert.Equal(CommandType.City, command.Type);
        }

        [Fact]
        public void ParserCanReturnSeveralCommands()
        {
            var sut = new CommandParser();
            var commands = sut.ParseCommand("-c Vilnius, Riga, Tallinn, New York");
            Assert.True(commands.Count() == 4);
        }

        [Fact]
        public void ArgsWithoutDashReturnEmpty()
        {
            var sut = new CommandParser();
            Assert.False(sut.ParseCommand("c asdqwd").Any());
        }

        [Fact]
        public void ArgsWithoutValueReturnEmpty()
        {
            var sut = new CommandParser();
            Assert.False(sut.ParseCommand("-c ").Any());
            Assert.False(sut.ParseCommand("--city ").Any());
        }

        [Fact]
        public void ArgsWithoutSpaceReturnEmpty()
        {
            var sut = new CommandParser();
            Assert.False(sut.ParseCommand("-cVilnius").Any());
            Assert.False(sut.ParseCommand("--cityVilnius").Any());
        }

        [Fact]
        public void EmptyArgsReturnEmpty()
        {
            var sut = new CommandParser();
            Assert.False(sut.ParseCommand("").Any());
            Assert.False(sut.ParseCommand(null).Any());
        }
    }
}

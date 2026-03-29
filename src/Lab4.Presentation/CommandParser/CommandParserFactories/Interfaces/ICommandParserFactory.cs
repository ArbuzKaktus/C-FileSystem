using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.CommandParserFactories.Interfaces;

public interface ICommandParserFactory
{
    ICommandParser Create();
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;

public interface ICommandParserLink : ICommandParser
{
    ICommandParserLink AddNext(ICommandParserLink link);
}
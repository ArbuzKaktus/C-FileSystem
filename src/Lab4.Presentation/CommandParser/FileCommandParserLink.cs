using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public class FileCommandParserLink : CommandParserLinkBase
{
    private readonly ICommandParser _subCommandParser;

    public FileCommandParserLink(ICommandParser subCommandParser)
    {
        _subCommandParser = subCommandParser;
    }

    public override ParserResult Parse(TokenIterator input)
    {
        int startPosition = input.Index;
        string? command = input.NextToken();

        if (command == null || !command.Equals("File", StringComparison.OrdinalIgnoreCase))
        {
            input.SetIndex(startPosition);
            return CallNext(input);
        }

        ParserResult result = _subCommandParser.Parse(input);

        if (result is ParserResult.Success)
        {
            return result;
        }

        input.SetIndex(startPosition);
        return CallNext(input);
    }
}

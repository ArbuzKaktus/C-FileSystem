using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.DisconnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public class DisconnectCommandParserLink : CommandParserLinkBase
{
    public override ParserResult Parse(TokenIterator input)
    {
        int startPosition = input.Index;
        string? command = input.NextToken();

        if (command != null && command.Equals("Disconnect", StringComparison.OrdinalIgnoreCase))
        {
            return new ParserResult.Success(new DisconnectCommandBuilder());
        }

        input.SetIndex(startPosition);
        return CallNext(input);
    }
}
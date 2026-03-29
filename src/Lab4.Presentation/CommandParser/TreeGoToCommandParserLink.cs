using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeGoToCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public class TreeGoToCommandParserLink : CommandParserLinkBase
{
    private readonly IParameterHandler _parameterChain;

    public TreeGoToCommandParserLink(IParameterHandler parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParserResult Parse(TokenIterator input)
    {
        int startPosition = input.Index;

        string? command = input.NextToken();

        if (command == null || !command.Equals("Goto", StringComparison.OrdinalIgnoreCase))
        {
            input.SetIndex(startPosition);
            return CallNext(input);
        }

        var builder = new TreeGoToCommandBuilder();

        _parameterChain.Handle(input, builder);

        if (builder.Path != null)
        {
            return new ParserResult.Success(builder);
        }

        input.SetIndex(startPosition);
        return CallNext(input);
    }
}
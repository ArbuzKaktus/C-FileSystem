using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public class FileMoveCommandParserLink : CommandParserLinkBase
{
    private readonly IParameterHandler _parameterChain;

    public FileMoveCommandParserLink(IParameterHandler parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParserResult Parse(TokenIterator input)
    {
        int startPosition = input.Index;

        string? command = input.NextToken();

        if (command == null || !command.Equals("Move", StringComparison.OrdinalIgnoreCase))
        {
            input.SetIndex(startPosition);
            return CallNext(input);
        }

        var builder = new FileMoveCommandBuilder();

        _parameterChain.Handle(input, builder);

        if (builder.FromPath != null && builder.ToPath != null)
        {
            return new ParserResult.Success(builder);
        }

        input.SetIndex(startPosition);
        return CallNext(input);
    }
}
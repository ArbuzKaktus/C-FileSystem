using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser;

public class TreeListCommandParserLink : CommandParserLinkBase
{
    private readonly IParameterHandler _parameterChain;

    public TreeListCommandParserLink(IParameterHandler parameterChain)
    {
        _parameterChain = parameterChain;
    }

    public override ParserResult Parse(TokenIterator input)
    {
        int startPosition = input.Index;

        string? command = input.NextToken();

        if (command == null || !command.Equals("List", StringComparison.OrdinalIgnoreCase))
        {
            input.SetIndex(startPosition);
            return CallNext(input);
        }

        var builder = new TreeListCommandBuilder();

        _parameterChain.Handle(input, builder);

        return new ParserResult.Success(builder);
    }
}
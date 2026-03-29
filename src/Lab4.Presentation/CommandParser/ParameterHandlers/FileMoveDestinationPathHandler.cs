using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileMoveDestinationPathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? toPath = iterator.NextToken();

        if (toPath != null && builder is FileMoveCommandBuilder fileMoveBuilder)
        {
            fileMoveBuilder.WithToPath(toPath);
        }

        base.Handle(iterator, builder);
    }
}

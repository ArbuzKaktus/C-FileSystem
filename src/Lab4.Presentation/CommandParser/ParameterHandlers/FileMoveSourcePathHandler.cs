using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileMoveSourcePathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? fromPath = iterator.NextToken();

        if (fromPath != null && builder is FileMoveCommandBuilder fileMoveBuilder)
        {
            fileMoveBuilder.WithFromPath(fromPath);
        }

        base.Handle(iterator, builder);
    }
}

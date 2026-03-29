using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileDeleteCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileDeletePathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? path = iterator.NextToken();

        if (path != null && builder is FileDeleteCommandBuilder fileDeleteBuilder)
        {
            fileDeleteBuilder.WithPath(path);
        }

        base.Handle(iterator, builder);
    }
}

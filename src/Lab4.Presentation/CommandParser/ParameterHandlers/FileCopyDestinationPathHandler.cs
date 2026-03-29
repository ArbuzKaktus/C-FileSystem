using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileCopyDestinationPathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? toPath = iterator.NextToken();

        if (toPath != null && builder is FileCopyCommandBuilder fileCopyBuilder)
        {
            fileCopyBuilder.WithToPath(toPath);
        }

        base.Handle(iterator, builder);
    }
}

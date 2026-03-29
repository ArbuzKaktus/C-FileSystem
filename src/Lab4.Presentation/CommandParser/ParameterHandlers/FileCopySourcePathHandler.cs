using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileCopySourcePathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? fromPath = iterator.NextToken();

        if (fromPath != null && builder is FileCopyCommandBuilder fileCopyBuilder)
        {
            fileCopyBuilder.WithFromPath(fromPath);
        }

        base.Handle(iterator, builder);
    }
}

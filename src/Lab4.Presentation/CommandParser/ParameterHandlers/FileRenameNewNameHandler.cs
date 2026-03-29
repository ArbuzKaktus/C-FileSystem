using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileRenameCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileRenameNewNameHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? newName = iterator.NextToken();

        if (newName != null && builder is FileRenameCommandBuilder fileRenameBuilder)
        {
            fileRenameBuilder.WithNewName(newName);
        }

        base.Handle(iterator, builder);
    }
}

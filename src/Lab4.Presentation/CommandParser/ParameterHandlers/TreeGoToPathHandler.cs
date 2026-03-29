using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeGoToCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class TreeGoToPathHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? path = iterator.NextToken();

        if (path != null && builder is TreeGoToCommandBuilder treeGoToBuilder)
        {
            treeGoToBuilder.WithPath(path);
        }

        base.Handle(iterator, builder);
    }
}

using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class TreeListDepthFlagHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        while (!iterator.IsEnd)
        {
            int startPosition = iterator.Index;
            string? token = iterator.NextToken();

            if (token != null && token.Equals("-d", StringComparison.OrdinalIgnoreCase))
            {
                string? depthString = iterator.NextToken();

                if (depthString != null && depthString.All(char.IsDigit) && builder is TreeListCommandBuilder treeListBuilder)
                {
                    int depth = int.Parse(depthString);
                    treeListBuilder.WithDepth(depth);
                }
            }
            else if (token != null)
            {
                iterator.SetIndex(startPosition);
                break;
            }
        }

        base.Handle(iterator, builder);
    }
}

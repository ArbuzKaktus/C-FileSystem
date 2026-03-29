using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeListCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class TreeListDependenciesHandler : ParameterHandlerBase
{
    private readonly IWriter _writer;
    private readonly ITreeListConfig _config;

    public TreeListDependenciesHandler(IWriter writer, ITreeListConfig config)
    {
        _writer = writer;
        _config = config;
    }

    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        if (builder is TreeListCommandBuilder treeListBuilder)
        {
            treeListBuilder.WithWriter(_writer).WithConfig(_config);
        }

        base.Handle(iterator, builder);
    }
}

using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeListCommandBuilders;

public class TreeListCommandBuilder : ICommandBuilder
{
    public int Depth { get; private set; } = 1;

    public IWriter? Writer { get; private set; }

    public ITreeListConfig? Config { get; private set; }

    public TreeListCommandBuilder WithDepth(int depth)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(depth, 1);
        Depth = depth;
        return this;
    }

    public TreeListCommandBuilder WithWriter(IWriter writer)
    {
        Writer = writer;
        return this;
    }

    public TreeListCommandBuilder WithConfig(ITreeListConfig config)
    {
        Config = config;
        return this;
    }

    public ICommand Build()
    {
        if (Writer is null)
        {
            throw new InvalidOperationException("Writer is required for TreeListCommand");
        }

        if (Config is null)
        {
            throw new InvalidOperationException("Config is required for TreeListCommand");
        }

        return new ConnectedCommand(new TreeListCommand(new TreeListVisitor(Writer, Config, Depth)));
    }
}
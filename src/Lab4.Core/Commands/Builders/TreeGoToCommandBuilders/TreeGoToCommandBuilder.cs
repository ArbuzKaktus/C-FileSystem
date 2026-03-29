using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeGoToCommandBuilders;

public class TreeGoToCommandBuilder : ICommandBuilder
{
    public string? Path { get; private set; }

    public TreeGoToCommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path))
        {
            throw new InvalidOperationException("Path is required for TreeGoToCommand");
        }

        return new ConnectedCommand(new TreeGoToCommand(Path));
    }
}
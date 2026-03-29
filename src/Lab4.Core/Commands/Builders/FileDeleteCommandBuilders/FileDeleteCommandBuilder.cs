using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileDeleteCommandBuilders;

public class FileDeleteCommandBuilder : ICommandBuilder
{
    public string? Path { get; private set; }

    public FileDeleteCommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path))
        {
            throw new InvalidOperationException("Path is required for FileDeleteCommand");
        }

        return new ConnectedCommand(new FileDeleteCommand(Path));
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders;

public class FileMoveCommandBuilder : ICommandBuilder
{
    public string? FromPath { get; private set; }

    public string? ToPath { get; private set; }

    public FileMoveCommandBuilder WithFromPath(string fromPath)
    {
        FromPath = fromPath;
        return this;
    }

    public FileMoveCommandBuilder WithToPath(string toPath)
    {
        ToPath = toPath;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(FromPath))
        {
            throw new InvalidOperationException("FromPath is required for FileMoveCommand");
        }

        if (string.IsNullOrEmpty(ToPath))
        {
            throw new InvalidOperationException("ToPath is required for FileMoveCommand");
        }

        return new ConnectedCommand(new FileMoveCommand(FromPath, ToPath));
    }
}
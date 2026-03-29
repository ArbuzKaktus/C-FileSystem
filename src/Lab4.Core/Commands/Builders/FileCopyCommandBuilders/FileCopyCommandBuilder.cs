using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders;

public class FileCopyCommandBuilder : ICommandBuilder
{
    public string? FromPath { get; private set; }

    public string? ToPath { get; private set; }

    public FileCopyCommandBuilder WithFromPath(string fromPath)
    {
        FromPath = fromPath;
        return this;
    }

    public FileCopyCommandBuilder WithToPath(string toPath)
    {
        ToPath = toPath;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(FromPath))
        {
            throw new InvalidOperationException("FromPath is required for FileCopyCommand");
        }

        if (string.IsNullOrEmpty(ToPath))
        {
            throw new InvalidOperationException("ToPath is required for FileCopyCommand");
        }

        return new ConnectedCommand(new FileCopyCommand(FromPath, ToPath));
    }
}
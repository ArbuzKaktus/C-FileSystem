using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileRenameCommandBuilders;

public class FileRenameCommandBuilder : ICommandBuilder
{
    public string? Path { get; private set; }

    public string? NewName { get; private set; }

    public FileRenameCommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public FileRenameCommandBuilder WithNewName(string newName)
    {
        NewName = newName;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path))
        {
            throw new InvalidOperationException("Path is required for FileRenameCommand");
        }

        if (string.IsNullOrEmpty(NewName))
        {
            throw new InvalidOperationException("NewName is required for FileRenameCommand");
        }

        return new ConnectedCommand(new FileRenameCommand(Path, NewName));
    }
}
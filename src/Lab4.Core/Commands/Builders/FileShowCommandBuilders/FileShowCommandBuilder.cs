using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileShowCommandBuilders;

public class FileShowCommandBuilder : ICommandBuilder
{
    public string? Path { get; private set; }

    public IFileViewer FileViewer { get; private set; }

    public FileShowCommandBuilder()
    {
        FileViewer = new ConsoleFileViewer();
    }

    public FileShowCommandBuilder WithPath(string path)
    {
        Path = path;
        return this;
    }

    public FileShowCommandBuilder WithFileViewer(IFileViewer fileViewer)
    {
        FileViewer = fileViewer;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Path))
        {
            throw new InvalidOperationException("Path is required for FileShowCommand");
        }

        return new ConnectedCommand(new FileShowCommand(Path, FileViewer));
    }
}
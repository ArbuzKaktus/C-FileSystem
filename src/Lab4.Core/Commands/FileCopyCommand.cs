using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileCopyCommand : ICommand
{
    private readonly string _fromPath;
    private readonly string _toPath;

    public FileCopyCommand(string fromPath, string toPath)
    {
        _fromPath = fromPath;
        _toPath = toPath;
    }

    public CommandResult Execute(Session currentSession)
    {
        if (currentSession.FileSystem is null)
        {
            return new CommandResult.Failure();
        }

        PathResolveResult absoluteFromPath = currentSession.ResolvePath(_fromPath);
        if (absoluteFromPath is not PathResolveResult.Success resultFromPath)
        {
            return new CommandResult.Failure();
        }

        PathResolveResult absoluteToPath = currentSession.ResolvePath(_toPath);
        if (absoluteToPath is not PathResolveResult.Success resultToPath)
        {
            return new CommandResult.Failure();
        }

        IFileSystem fileSystem = currentSession.FileSystem;

        FileSystemResult result = fileSystem.CopyFile(resultFromPath.Result, resultToPath.Result);

        return result is FileSystemResult.Success ? new CommandResult.Success() : new CommandResult.Failure();
    }
}
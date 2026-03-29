using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileMoveCommand : ICommand
{
    private readonly string _fromPath;
    private readonly string _toPath;

    public FileMoveCommand(string fromPath, string toPath)
    {
        _fromPath = fromPath;
        _toPath = toPath;
    }

    public CommandResult Execute(Session currentSession)
    {
        PathResolveResult absoluteSource = currentSession.ResolvePath(_fromPath);
        PathResolveResult absoluteDestination = currentSession.ResolvePath(_toPath);

        if (absoluteSource is not PathResolveResult.Success sourceResult || absoluteDestination is not PathResolveResult.Success destinationResult)
        {
            return new CommandResult.Failure();
        }

        IFileSystem? fileSystem = currentSession.FileSystem;

        if (fileSystem is null)
        {
            return new CommandResult.Failure();
        }

        FileSystemResult result = fileSystem.MoveFile(sourceResult.Result, destinationResult.Result);

        return result is FileSystemResult.Success ? new CommandResult.Success() : new CommandResult.Failure();
    }
}
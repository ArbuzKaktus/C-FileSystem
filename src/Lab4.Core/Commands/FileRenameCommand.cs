using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _newName;

    public FileRenameCommand(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public CommandResult Execute(Session currentSession)
    {
        PathResolveResult absolutePath = currentSession.ResolvePath(_path);
        IFileSystem? fileSystem = currentSession.FileSystem;
        if (absolutePath is not PathResolveResult.Success resultPath || fileSystem is null)
        {
            return new CommandResult.Failure();
        }

        FileSystemResult result = fileSystem.RenameFile(resultPath.Result, _newName);

        return result is FileSystemResult.Success ? new CommandResult.Success() : new CommandResult.Failure();
    }
}
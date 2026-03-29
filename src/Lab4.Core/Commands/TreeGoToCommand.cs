using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public CommandResult Execute(Session currentSession)
    {
        PathResolveResult absolutePath = currentSession.ResolvePath(_path);

        if (absolutePath is not PathResolveResult.Success pathResult)
        {
            return new CommandResult.Failure();
        }

        IFileSystem? fileSystem = currentSession.FileSystem;

        return fileSystem != null && fileSystem.IsDirectory(pathResult.Result)
            ? currentSession.ChangeDirectory(pathResult.Result)
            : new CommandResult.Failure();
    }
}
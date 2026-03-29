using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _path;

    public FileDeleteCommand(string path)
    {
        _path = path;
    }

    public CommandResult Execute(Session currentSession)
    {
        PathResolveResult resolvedFilePath = currentSession.ResolvePath(_path);

        if (resolvedFilePath is not PathResolveResult.Success result) return new CommandResult.Failure();

        currentSession.FileSystem?.DeleteFile(result.Result);
        return new CommandResult.Success();
    }
}
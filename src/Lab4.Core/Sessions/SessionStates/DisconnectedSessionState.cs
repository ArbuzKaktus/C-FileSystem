using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public class DisconnectedSessionState : ISessionState
{
    public bool IsConnected => false;

    public CommandResult Connect(SessionContext context, string fullPath, IFileSystem fileSystem)
    {
        context.RootPath = fullPath;
        context.CurrentPath = fullPath;
        context.FileSystem = fileSystem;

        context.ChangeState(new ConnectedSessionState());
        return new CommandResult.Success();
    }

    public CommandResult Disconnect(SessionContext context)
    {
        return new CommandResult.Failure();
    }

    public CommandResult ChangeDirectory(SessionContext context, string newPath)
    {
        return new CommandResult.Failure();
    }
}
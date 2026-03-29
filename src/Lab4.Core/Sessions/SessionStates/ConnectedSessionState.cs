using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

public class ConnectedSessionState : ISessionState
{
    public bool IsConnected => true;

    public CommandResult Connect(SessionContext context, string fullPath, IFileSystem fileSystem)
    {
        return new CommandResult.Failure();
    }

    public CommandResult Disconnect(SessionContext context)
    {
        context.FileSystem = null;
        context.CurrentPath = null;
        context.RootPath = null;

        context.ChangeState(new DisconnectedSessionState());
        return new CommandResult.Success();
    }

    public CommandResult ChangeDirectory(SessionContext context, string newPath)
    {
        context.CurrentPath = newPath;

        return new CommandResult.Success();
    }
}
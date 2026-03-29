using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates.Interfaces;

public interface ISessionState
{
    bool IsConnected { get; }

    CommandResult Connect(SessionContext context, string fullPath, IFileSystem fileSystem);

    CommandResult Disconnect(SessionContext context);

    CommandResult ChangeDirectory(SessionContext context, string newPath);
}
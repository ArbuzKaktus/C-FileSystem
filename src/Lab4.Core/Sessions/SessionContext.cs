using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

public class SessionContext
{
    public SessionContext(ISessionState initialState)
    {
        State = initialState;
    }

    public ISessionState State { get; private set; }

    public IFileSystem? FileSystem { get; set; }

    public string? RootPath { get; set; }

    public string? CurrentPath { get; set; }

    public void ChangeState(ISessionState state)
    {
        State = state;
    }
}
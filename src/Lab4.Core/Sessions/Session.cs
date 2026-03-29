using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathResolvers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions.SessionStates;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

public class Session
{
    private readonly SessionContext _context = new(new DisconnectedSessionState());
    private readonly IPathResolver _resolver;

    public Session(IPathResolver resolver)
    {
        _resolver = resolver;
    }

    public IFileSystem? FileSystem => _context.FileSystem;

    public string? RootPath => _context.RootPath;

    public string? CurrentPath => _context.CurrentPath;

    public bool IsConnected => _context.State.IsConnected;

    public CommandResult Connect(string fullPath, IFileSystem fileSystem)
    {
        return _context.State.Connect(_context, fullPath, fileSystem);
    }

    public CommandResult Disconnect()
    {
        return _context.State.Disconnect(_context);
    }

    public CommandResult ChangeDirectory(string newPath)
    {
        return _context.State.ChangeDirectory(_context, newPath);
    }

    public PathResolveResult ResolvePath(string path)
    {
        return CurrentPath is not null && RootPath is not null
            ? _resolver.Resolve(path, CurrentPath, RootPath)
            : new PathResolveResult.Failure();
    }
}
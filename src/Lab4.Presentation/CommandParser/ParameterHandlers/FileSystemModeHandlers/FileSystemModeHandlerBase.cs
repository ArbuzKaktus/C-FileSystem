using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;

public abstract class FileSystemModeHandlerBase : IFileSystemModeHandler
{
    private IFileSystemModeHandler? _nextHandler;

    public IFileSystemModeHandler? SetNext(IFileSystemModeHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual IFileSystem? Handle(string mode)
    {
        return _nextHandler?.Handle(mode);
    }
}

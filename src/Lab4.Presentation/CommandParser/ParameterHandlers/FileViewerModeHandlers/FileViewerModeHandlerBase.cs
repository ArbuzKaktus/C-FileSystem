using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;

public abstract class FileViewerModeHandlerBase : IFileViewerModeHandler
{
    private IFileViewerModeHandler? _nextHandler;

    public IFileViewerModeHandler? SetNext(IFileViewerModeHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual IFileViewer? Handle(string mode)
    {
        return _nextHandler?.Handle(mode);
    }
}

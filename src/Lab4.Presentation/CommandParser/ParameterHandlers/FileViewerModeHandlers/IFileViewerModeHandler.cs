using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;

public interface IFileViewerModeHandler
{
    IFileViewerModeHandler? SetNext(IFileViewerModeHandler handler);

    IFileViewer? Handle(string mode);
}

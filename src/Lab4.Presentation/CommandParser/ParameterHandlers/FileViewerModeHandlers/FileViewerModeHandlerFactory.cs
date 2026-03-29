using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;

public class FileViewerModeHandlerFactory : IFileViewerModeHandlerFactory
{
    public IFileViewerModeHandler Create()
    {
        return new ConsoleFileViewerModeHandler();
    }
}

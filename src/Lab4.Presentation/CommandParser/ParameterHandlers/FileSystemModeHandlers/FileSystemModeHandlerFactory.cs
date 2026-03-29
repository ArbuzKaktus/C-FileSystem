using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;

public class FileSystemModeHandlerFactory : IFileSystemModeHandlerFactory
{
    public IFileSystemModeHandler Create()
    {
        return new LocalFileSystemModeHandler();
    }
}

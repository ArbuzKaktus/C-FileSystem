using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;

public interface IFileSystemModeHandler
{
    IFileSystemModeHandler? SetNext(IFileSystemModeHandler handler);

    IFileSystem? Handle(string mode);
}

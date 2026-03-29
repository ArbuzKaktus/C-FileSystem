using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;

public class LocalFileSystemModeHandler : FileSystemModeHandlerBase
{
    public override IFileSystem? Handle(string mode)
    {
        return mode.Equals("local", StringComparison.OrdinalIgnoreCase) ? new LocalFileSystem() : base.Handle(mode);
    }
}

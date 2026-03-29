using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;

public class ConsoleFileViewerModeHandler : FileViewerModeHandlerBase
{
    public override IFileViewer? Handle(string mode)
    {
        return mode.Equals("console", StringComparison.OrdinalIgnoreCase) ? new ConsoleFileViewer() : base.Handle(mode);
    }
}

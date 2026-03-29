using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileShowCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class FileShowModeFlagHandler : ParameterHandlerBase
{
    private readonly IFileViewerModeHandler _fileViewerModeChain;

    public FileShowModeFlagHandler(IFileViewerModeHandler fileViewerModeChain)
    {
        _fileViewerModeChain = fileViewerModeChain;
    }

    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        while (!iterator.IsEnd)
        {
            int startPosition = iterator.Index;
            string? token = iterator.NextToken();

            if (token != null && token.Equals("-m", StringComparison.OrdinalIgnoreCase))
            {
                string? mode = iterator.NextToken();

                if (mode == null || builder is not FileShowCommandBuilder fileShowBuilder) continue;

                IFileViewer? fileViewer = _fileViewerModeChain.Handle(mode);

                if (fileViewer == null) continue;
                fileShowBuilder.WithFileViewer(fileViewer);
            }
            else if (token != null)
            {
                iterator.SetIndex(startPosition);
                break;
            }
        }

        base.Handle(iterator, builder);
    }
}

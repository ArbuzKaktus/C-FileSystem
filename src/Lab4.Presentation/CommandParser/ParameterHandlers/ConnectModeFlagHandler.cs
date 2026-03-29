using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class ConnectModeFlagHandler : ParameterHandlerBase
{
    private readonly IFileSystemModeHandler _fileSystemModeChain;

    public ConnectModeFlagHandler(IFileSystemModeHandler fileSystemModeChain)
    {
        _fileSystemModeChain = fileSystemModeChain;
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

                if (mode == null || builder is not ConnectCommandBuilder connectBuilder) continue;

                IFileSystem? fileSystem = _fileSystemModeChain.Handle(mode);

                if (fileSystem == null) continue;
                connectBuilder.WithFileSystem(fileSystem);
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

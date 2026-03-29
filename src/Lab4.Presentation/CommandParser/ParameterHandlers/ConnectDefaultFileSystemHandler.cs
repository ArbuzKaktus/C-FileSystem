using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class ConnectDefaultFileSystemHandler : ParameterHandlerBase
{
    private readonly IFileSystem _defaultFileSystem;

    public ConnectDefaultFileSystemHandler(IFileSystem defaultFileSystem)
    {
        _defaultFileSystem = defaultFileSystem;
    }

    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        if (builder is ConnectCommandBuilder connectBuilder && connectBuilder.FileSystem is null)
        {
            connectBuilder.WithFileSystem(_defaultFileSystem);
        }

        base.Handle(iterator, builder);
    }
}

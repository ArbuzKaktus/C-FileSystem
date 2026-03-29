using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.CommandParserFactories.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileSystemModeHandlers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.FileViewerModeHandlers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.CommandParserFactories;

public class CommandParserFactory : ICommandParserFactory
{
    private readonly IWriter _writer;
    private readonly IFileSystemModeHandlerFactory _fileSystemModeHandlerFactory;
    private readonly IFileViewerModeHandlerFactory _fileViewerModeHandlerFactory;

    public CommandParserFactory(
        IWriter writer,
        IFileSystemModeHandlerFactory fileSystemModeHandlerFactory,
        IFileViewerModeHandlerFactory fileViewerModeHandlerFactory)
    {
        _writer = writer;
        _fileSystemModeHandlerFactory = fileSystemModeHandlerFactory;
        _fileViewerModeHandlerFactory = fileViewerModeHandlerFactory;
    }

    public ICommandParser Create()
    {
        ICommandParser fileSubCommands = new FileCopyCommandParserLink(CreateFileCopyParameterChain())
            .AddNext(new FileDeleteCommandParserLink(CreateFileDeleteParameterChain()))
            .AddNext(new FileMoveCommandParserLink(CreateFileMoveParameterChain()))
            .AddNext(new FileRenameCommandParserLink(CreateFileRenameParameterChain()))
            .AddNext(new FileShowCommandParserLink(CreateFileShowParameterChain()));

        ICommandParser treeSubCommands = new TreeGoToCommandParserLink(CreateTreeGoToParameterChain())
            .AddNext(new TreeListCommandParserLink(CreateTreeListParameterChain()));

        return new ConnectCommandParserLink(CreateConnectParameterChain())
            .AddNext(new DisconnectCommandParserLink())
            .AddNext(new FileCommandParserLink(fileSubCommands))
            .AddNext(new TreeCommandParserLink(treeSubCommands));
    }

    private ConnectAddressParameterHandler CreateConnectParameterChain()
    {
        IFileSystemModeHandler fileSystemModeHandler = _fileSystemModeHandlerFactory.Create();

        var addressHandler = new ConnectAddressParameterHandler();
        var modeHandler = new ConnectModeFlagHandler(fileSystemModeHandler);
        var defaultFileSystemHandler = new ConnectDefaultFileSystemHandler(new LocalFileSystem());

        addressHandler.SetNext(modeHandler);
        modeHandler.SetNext(defaultFileSystemHandler);
        return addressHandler;
    }

    private FileCopySourcePathHandler CreateFileCopyParameterChain()
    {
        var sourcePathHandler = new FileCopySourcePathHandler();
        var destinationPathHandler = new FileCopyDestinationPathHandler();

        sourcePathHandler.SetNext(destinationPathHandler);
        return sourcePathHandler;
    }

    private FileDeletePathHandler CreateFileDeleteParameterChain()
    {
        return new FileDeletePathHandler();
    }

    private FileMoveSourcePathHandler CreateFileMoveParameterChain()
    {
        var sourcePathHandler = new FileMoveSourcePathHandler();
        var destinationPathHandler = new FileMoveDestinationPathHandler();

        sourcePathHandler.SetNext(destinationPathHandler);
        return sourcePathHandler;
    }

    private FileRenamePathHandler CreateFileRenameParameterChain()
    {
        var pathHandler = new FileRenamePathHandler();
        var newNameHandler = new FileRenameNewNameHandler();

        pathHandler.SetNext(newNameHandler);
        return pathHandler;
    }

    private FileShowPathHandler CreateFileShowParameterChain()
    {
        IFileViewerModeHandler fileViewerModeHandler = _fileViewerModeHandlerFactory.Create();

        var pathHandler = new FileShowPathHandler();
        var modeHandler = new FileShowModeFlagHandler(fileViewerModeHandler);

        pathHandler.SetNext(modeHandler);
        return pathHandler;
    }

    private TreeGoToPathHandler CreateTreeGoToParameterChain()
    {
        return new TreeGoToPathHandler();
    }

    private TreeListDependenciesHandler CreateTreeListParameterChain()
    {
        var dependenciesHandler = new TreeListDependenciesHandler(_writer, new TreeListConfig());
        var depthHandler = new TreeListDepthFlagHandler();

        dependenciesHandler.SetNext(depthHandler);
        return dependenciesHandler;
    }
}
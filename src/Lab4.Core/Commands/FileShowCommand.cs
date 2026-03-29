using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class FileShowCommand : ICommand
{
    private readonly string _filePath;
    private readonly IFileViewer _fileViewer;

    public FileShowCommand(string filePath, IFileViewer fileViewer)
    {
        _filePath = filePath;
        _fileViewer = fileViewer;
    }

    public CommandResult Execute(Session currentSession)
    {
        if (currentSession.FileSystem is null)
        {
            return new CommandResult.Failure();
        }

        PathResolveResult absolutePath = currentSession.ResolvePath(_filePath);

        if (absolutePath is not PathResolveResult.Success pathResult)
        {
            return new CommandResult.Failure();
        }

        IFileSystem? fileSystem = currentSession.FileSystem;

        if (!fileSystem.Exists(pathResult.Result) || fileSystem.IsDirectory(pathResult.Result))
        {
            return new CommandResult.Failure();
        }

        IEnumerable<string> content = fileSystem.OpenFile(pathResult.Result);
        _fileViewer.ViewFile(content);

        return new CommandResult.Success();
    }
}
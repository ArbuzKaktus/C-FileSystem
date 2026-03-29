using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class TreeListCommand : ICommand
{
    private readonly IFileSystemComponentVisitor _visitor;

    public TreeListCommand(IFileSystemComponentVisitor visitor)
    {
        _visitor = visitor;
    }

    public CommandResult Execute(Session currentSession)
    {
        if (currentSession.FileSystem is null || currentSession.CurrentPath is null)
        {
            return new CommandResult.Failure();
        }

        IFileSystem fileSystem = currentSession.FileSystem;

        var currentDirectory = new DirectoryComponent(
            fileSystem.GetFileName(currentSession.CurrentPath),
            currentSession.CurrentPath,
            fileSystem);

        currentDirectory.Accept(_visitor);
        return new CommandResult.Success();
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _address;
    private readonly IFileSystem _fileSystem;

    public ConnectCommand(string address, IFileSystem fileSystem)
    {
        _address = address;
        _fileSystem = fileSystem;
    }

    public CommandResult Execute(Session currentSession)
    {
        if (!_fileSystem.Exists(_address) || !_fileSystem.IsDirectory(_address))
        {
            return new CommandResult.Failure();
        }

        return currentSession.Connect(_address, _fileSystem);
    }
}
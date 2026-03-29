using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public class ConnectedCommand : ICommand
{
    private readonly ICommand _command;

    public ConnectedCommand(ICommand command)
    {
        _command = command;
    }

    public CommandResult Execute(Session currentSession)
    {
        return currentSession.IsConnected ? _command.Execute(currentSession) : new CommandResult.Failure();
    }
}
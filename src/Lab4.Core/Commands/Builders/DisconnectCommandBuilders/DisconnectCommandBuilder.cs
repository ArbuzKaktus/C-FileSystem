using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.DisconnectCommandBuilders;

public class DisconnectCommandBuilder : ICommandBuilder
{
    public ICommand Build()
    {
        return new ConnectedCommand(new DisconnectCommand());
    }
}
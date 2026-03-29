using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders.Interfaces;

public interface IWithAddressConnectBuilder
{
    ICommandBuilder WithMode(string mode);
}
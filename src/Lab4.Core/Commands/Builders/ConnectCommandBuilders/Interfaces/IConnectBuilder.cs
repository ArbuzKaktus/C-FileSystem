namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders.Interfaces;

public interface IConnectBuilder
{
    IWithAddressConnectBuilder WithAddress(string address);
}
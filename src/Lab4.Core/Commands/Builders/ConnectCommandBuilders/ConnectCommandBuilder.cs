using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders;

public class ConnectCommandBuilder : ICommandBuilder
{
    public string? Address { get; private set; }

    public IFileSystem? FileSystem { get; private set; }

    public ConnectCommandBuilder WithAddress(string address)
    {
        Address = address;
        return this;
    }

    public ConnectCommandBuilder WithFileSystem(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
        return this;
    }

    public ICommand Build()
    {
        if (string.IsNullOrEmpty(Address))
        {
            throw new InvalidOperationException("Address is required for ConnectCommand");
        }

        if (FileSystem is null)
        {
            throw new InvalidOperationException("FileSystem is required for ConnectCommand");
        }

        return new ConnectCommand(Address, FileSystem);
    }
}
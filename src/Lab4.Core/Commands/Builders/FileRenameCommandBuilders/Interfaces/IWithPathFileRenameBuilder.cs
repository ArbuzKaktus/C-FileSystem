using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileRenameCommandBuilders.Interfaces;

public interface IWithPathFileRenameBuilder
{
    ICommandBuilder WithNewName(string newName);
}
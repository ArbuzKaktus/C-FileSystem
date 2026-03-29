using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders.Interfaces;

public interface IWithFromPathFileMoveBuilder
{
    ICommandBuilder WithToPath(string toPath);
}
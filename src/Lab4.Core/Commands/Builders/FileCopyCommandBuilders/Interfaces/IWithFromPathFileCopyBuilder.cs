using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders.Interfaces;

public interface IWithFromPathFileCopyBuilder
{
    ICommandBuilder WithToPath(string toPath);
}
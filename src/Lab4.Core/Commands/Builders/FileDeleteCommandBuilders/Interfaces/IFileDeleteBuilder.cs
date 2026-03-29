using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileDeleteCommandBuilders.Interfaces;

public interface IFileDeleteBuilder
{
    ICommandBuilder WithPath(string path);
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.TreeGoToCommandBuilders.Interfaces;

public interface ITreeGoToBuilder
{
    ICommandBuilder WithPath(string path);
}
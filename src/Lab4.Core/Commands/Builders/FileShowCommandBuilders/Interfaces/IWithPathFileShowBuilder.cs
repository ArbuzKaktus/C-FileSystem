using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileShowCommandBuilders.Interfaces;

public interface IWithPathFileShowBuilder
{
    ICommandBuilder WithMode(string mode);
}
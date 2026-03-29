namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileShowCommandBuilders.Interfaces;

public interface IFileShowBuilder
{
    IWithPathFileShowBuilder WithPath(string path);
}
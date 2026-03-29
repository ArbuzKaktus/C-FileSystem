namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileMoveCommandBuilders.Interfaces;

public interface IFileMoveBuilder
{
    IWithFromPathFileMoveBuilder WithFromPath(string fromPath);
}
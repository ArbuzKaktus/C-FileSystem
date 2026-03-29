namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileCopyCommandBuilders.Interfaces;

public interface IFileCopyBuilder
{
    IWithFromPathFileCopyBuilder WithFromPath(string fromPath);
}
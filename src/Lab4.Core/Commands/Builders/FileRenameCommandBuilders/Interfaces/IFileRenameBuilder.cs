namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.FileRenameCommandBuilders.Interfaces;

public interface IFileRenameBuilder
{
    IWithPathFileRenameBuilder WithPath(string path);
}
namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.SystemHandler.Interfaces;

public interface IFileSystemFactoryLink : IFileSystemFactoryService
{
    IFileSystemFactoryLink AddNext(IFileSystemFactoryLink link);
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.SystemHandler.Interfaces;

public interface IFileSystemFactoryService
{
    IFileSystemFactory? Apply(string mode);
}
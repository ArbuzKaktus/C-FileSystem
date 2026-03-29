using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.Interfaces;

public interface IFileSystemFactory
{
    IFileSystem CreateFileSystem();
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory;

public class LocalFileSystemFactory : IFileSystemFactory
{
    public IFileSystem CreateFileSystem()
    {
        return new LocalFileSystem();
    }
}
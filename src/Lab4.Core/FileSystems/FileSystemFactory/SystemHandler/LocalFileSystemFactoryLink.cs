using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.SystemHandler;

public class LocalFileSystemFactoryLink : FileSystemFactoryLinkBase
{
    public override IFileSystemFactory? Apply(string mode)
    {
        return mode.Equals("local", StringComparison.OrdinalIgnoreCase) ? new LocalFileSystemFactory() : CallNext(mode);
    }
}
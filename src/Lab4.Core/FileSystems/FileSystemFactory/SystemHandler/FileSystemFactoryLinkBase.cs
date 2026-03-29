using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.SystemHandler.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactory.SystemHandler;

public abstract class FileSystemFactoryLinkBase : IFileSystemFactoryLink
{
    private IFileSystemFactoryLink? _next;

    public IFileSystemFactoryLink AddNext(IFileSystemFactoryLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract IFileSystemFactory? Apply(string mode);

    protected IFileSystemFactory? CallNext(string mode)
    {
        return _next?.Apply(mode) ?? null;
    }
}
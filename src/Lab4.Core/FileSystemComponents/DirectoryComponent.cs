using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

public class DirectoryComponent : IFileSystemComponent
{
    private readonly IFileSystem _fileSystem;

    public DirectoryComponent(string name, string fullPath, IFileSystem fileSystem)
    {
        Name = name;
        FullPath = fullPath;
        _fileSystem = fileSystem;
    }

    public string Name { get; }

    public string FullPath { get; }

    public IEnumerable<IFileSystemComponent> GetChildren()
    {
        return _fileSystem.GetChildren(FullPath);
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
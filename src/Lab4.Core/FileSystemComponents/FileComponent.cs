using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

public class FileComponent : IFileSystemComponent
{
    public FileComponent(string name, string fullPath)
    {
        Name = name;
        FullPath = fullPath;
    }

    public string Name { get; }

    public string FullPath { get; }

    public IEnumerable<IFileSystemComponent> GetChildren()
    {
        return [];
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}
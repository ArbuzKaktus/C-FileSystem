using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;

public interface IFileSystemComponent
{
    string Name { get; }

    string FullPath { get; }

    IEnumerable<IFileSystemComponent> GetChildren();

    void Accept(IFileSystemComponentVisitor visitor);
}
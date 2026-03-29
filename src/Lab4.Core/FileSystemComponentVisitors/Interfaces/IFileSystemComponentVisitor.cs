using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;

public interface IFileSystemComponentVisitor
{
    void Visit(DirectoryComponent directory);

    void Visit(FileComponent file);
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;

public interface IFileSystem
{
    bool Exists(string path);

    bool IsDirectory(string path);

    IEnumerable<IFileSystemComponent> GetChildren(string path);

    string GetFileName(string path);

    FileSystemResult MoveFile(string fromPath, string toPath);

    FileSystemResult CopyFile(string fromPath, string toPath);

    FileSystemResult DeleteFile(string path);

    FileSystemResult RenameFile(string path, string newName);

    IEnumerable<string> OpenFile(string path);
}
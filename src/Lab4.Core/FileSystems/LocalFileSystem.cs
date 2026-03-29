using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool Exists(string path)
    {
        return File.Exists(path) || Directory.Exists(path);
    }

    public bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public IEnumerable<IFileSystemComponent> GetChildren(string path)
    {
        if (!IsDirectory(path))
        {
            yield break;
        }

        foreach (string directoryPath in Directory.EnumerateDirectories(path))
        {
            yield return new DirectoryComponent(GetFileName(directoryPath), directoryPath, this);
        }

        foreach (string filePath in Directory.EnumerateFiles(path))
        {
            yield return new FileComponent(GetFileName(filePath), filePath);
        }
    }

    public string GetFileName(string path)
    {
        return Path.GetFileName(path);
    }

    public FileSystemResult MoveFile(string fromPath, string toPath)
    {
        if (!File.Exists(fromPath))
        {
            return new FileSystemResult.Failure();
        }

        string newFilePath = GenerateUniquePath(toPath);
        File.Move(fromPath, newFilePath);
        return new FileSystemResult.Success();
    }

    public FileSystemResult CopyFile(string fromPath, string toPath)
    {
        if (!File.Exists(fromPath))
        {
            return new FileSystemResult.Failure();
        }

        string copyFilePath = GenerateUniquePath(toPath);
        File.Copy(fromPath, toPath);
        return new FileSystemResult.Success();
    }

    public FileSystemResult DeleteFile(string path)
    {
        if (!File.Exists(path))
        {
            return new FileSystemResult.Failure();
        }

        File.Delete(path);
        return new FileSystemResult.Failure();
    }

    public FileSystemResult RenameFile(string path, string newName)
    {
        if (!Exists(path))
        {
            return new FileSystemResult.Failure();
        }

        string? directory = Path.GetDirectoryName(path);
        if (directory == null)
        {
            return new FileSystemResult.Failure();
        }

        string newPath = Path.Combine(directory, newName);
        newPath = GenerateUniquePath(newPath);

        File.Move(path, newPath);

        return new FileSystemResult.Success();
    }

    public IEnumerable<string> OpenFile(string path)
    {
        return !File.Exists(path) ? [] : File.ReadLines(path);
    }

    private string GenerateUniquePath(string path)
    {
        string directory = Path.GetDirectoryName(path) ?? string.Empty;
        string fileName = Path.GetFileNameWithoutExtension(path);
        string fileExtension = Path.GetExtension(path);

        int counter = 1;
        string newPath = path;

        while (Exists(newPath))
        {
            string newFileName = $"{fileName} ({counter}){fileExtension}";
            newPath = Path.Combine(directory, newFileName);
            ++counter;
        }

        return newPath;
    }
}
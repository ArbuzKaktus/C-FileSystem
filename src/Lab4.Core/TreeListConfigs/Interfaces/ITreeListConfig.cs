namespace Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs.Interfaces;

public interface ITreeListConfig
{
    string FileIcon { get; }

    string DirectoryIcon { get; }

    string LastFileIcon { get; }

    string LastDirectoryIcon { get; }

    string VerticalLine { get; }

    string EmptySpace { get; }

    int WhitespaceCount { get; }
}
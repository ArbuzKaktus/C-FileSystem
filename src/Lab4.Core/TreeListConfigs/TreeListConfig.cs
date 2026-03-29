using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs;

public class TreeListConfig : ITreeListConfig
{
    public string FileIcon => "├── ";

    public string DirectoryIcon => "├── ";

    public string LastFileIcon => "└── ";

    public string LastDirectoryIcon => "└── ";

    public string VerticalLine => "│   ";

    public string EmptySpace => "    ";

    public int WhitespaceCount => 4;
}
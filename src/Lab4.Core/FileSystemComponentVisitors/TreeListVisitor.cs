using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponents;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.TreeListConfigs.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemComponentVisitors;

public class TreeListVisitor : IFileSystemComponentVisitor
{
    private readonly IWriter _writer;
    private readonly ITreeListConfig _config;
    private readonly int _maxDepth;
    private readonly List<bool> _isLastAtLevel = [];
    private int _currentDepth;

    public TreeListVisitor(IWriter writer, ITreeListConfig config, int maxDepth)
    {
        _writer = writer;
        _config = config;
        _maxDepth = maxDepth;
        _currentDepth = 0;
    }

    public void Visit(DirectoryComponent directory)
    {
        string prefix = GeneratePrefix();
        string icon = _isLastAtLevel.Count > 0 && _isLastAtLevel[^1]
            ? _config.LastDirectoryIcon
            : _config.DirectoryIcon;

        _writer.WriteLine($"{prefix}{icon}{directory.Name}");

        if (_currentDepth >= _maxDepth) return;

        _currentDepth++;

        var children = directory.GetChildren().ToList();
        for (int i = 0; i < children.Count; i++)
        {
            bool isLast = i == children.Count - 1;
            _isLastAtLevel.Add(isLast);
            children[i].Accept(this);
            _isLastAtLevel.RemoveAt(_isLastAtLevel.Count - 1);
        }

        _currentDepth--;
    }

    public void Visit(FileComponent file)
    {
        string prefix = GeneratePrefix();
        string icon = _isLastAtLevel.Count > 0 && _isLastAtLevel[^1]
            ? _config.LastFileIcon
            : _config.FileIcon;

        _writer.WriteLine($"{prefix}{icon}{file.Name}");
    }

    private string GeneratePrefix()
    {
        if (_isLastAtLevel.Count == 0) return string.Empty;

        string result = string.Empty;
        for (int i = 0; i < _isLastAtLevel.Count - 1; i++)
        {
            result += _isLastAtLevel[i] ? _config.EmptySpace : _config.VerticalLine;
        }

        return result;
    }
}
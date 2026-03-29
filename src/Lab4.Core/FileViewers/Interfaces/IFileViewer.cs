namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

public interface IFileViewer
{
    void ViewFile(IEnumerable<string> lines);
}
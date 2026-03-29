using Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileViewers;

public class ConsoleFileViewer : IFileViewer
{
    public void ViewFile(IEnumerable<string> lines)
    {
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

public class ConsoleWriter : IWriter
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}
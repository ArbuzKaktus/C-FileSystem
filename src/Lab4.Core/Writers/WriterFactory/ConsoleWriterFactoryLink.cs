using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterFactory;

public class ConsoleWriterFactoryLink : WriterFactoryLinkBase
{
    public override IWriter? Apply(string mode)
    {
        return mode.Equals("Console", StringComparison.OrdinalIgnoreCase) ? new ConsoleWriter() : CallNext(mode);
    }
}
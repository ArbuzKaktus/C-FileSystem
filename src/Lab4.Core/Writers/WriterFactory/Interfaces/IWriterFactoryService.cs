using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterFactory.Interfaces;

public interface IWriterFactoryService
{
    IWriter? Apply(string mode);
}
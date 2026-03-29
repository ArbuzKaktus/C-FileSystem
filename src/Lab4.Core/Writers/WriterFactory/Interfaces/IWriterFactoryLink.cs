namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterFactory.Interfaces;

public interface IWriterFactoryLink : IWriterFactoryService
{
    IWriterFactoryLink AddNext(IWriterFactoryLink link);
}
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterFactory.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterFactory;

public abstract class WriterFactoryLinkBase : IWriterFactoryLink
{
    private IWriterFactoryLink? _next;

    public abstract IWriter? Apply(string mode);

    public IWriterFactoryLink AddNext(IWriterFactoryLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected IWriter? CallNext(string mode)
    {
        return _next?.Apply(mode) ?? null;
    }
}
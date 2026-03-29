using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public abstract class ParameterHandlerBase : IParameterHandler
{
    private IParameterHandler? _nextHandler;

    public IParameterHandler? SetNext(IParameterHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        _nextHandler?.Handle(iterator, builder);
    }
}

using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers.Interfaces;

public interface IParameterHandler
{
    IParameterHandler? SetNext(IParameterHandler handler);

    void Handle(TokenIterator iterator, ICommandBuilder builder);
}

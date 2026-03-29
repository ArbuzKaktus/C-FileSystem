using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.ConnectCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.TokenIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.ParameterHandlers;

public class ConnectAddressParameterHandler : ParameterHandlerBase
{
    public override void Handle(TokenIterator iterator, ICommandBuilder builder)
    {
        string? address = iterator.NextToken();

        if (address != null && builder is ConnectCommandBuilder connectBuilder)
        {
            connectBuilder.WithAddress(address);
        }

        base.Handle(iterator, builder);
    }
}

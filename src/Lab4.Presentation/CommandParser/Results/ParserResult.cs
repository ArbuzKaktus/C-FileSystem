using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.CommandParser.Results;

public abstract record ParserResult
{
    private ParserResult() { }

    public sealed record Success(ICommandBuilder CommandBuilder) : ParserResult;

    public sealed record Failure() : ParserResult;
}
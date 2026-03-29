namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

public abstract record CommandResult
{
    private CommandResult() { }

    public sealed record Success() : CommandResult;

    public sealed record Failure() : CommandResult;
}
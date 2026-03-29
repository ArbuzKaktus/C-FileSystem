namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

public abstract record PathResolveResult
{
    private PathResolveResult() { }

    public sealed record Success(string Result) : PathResolveResult;

    public sealed record Failure() : PathResolveResult;
}
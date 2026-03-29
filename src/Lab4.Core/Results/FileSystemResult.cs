namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Results;

public abstract record FileSystemResult
{
    private FileSystemResult() { }

    public record Success() : FileSystemResult;

    public record Failure() : FileSystemResult;
}
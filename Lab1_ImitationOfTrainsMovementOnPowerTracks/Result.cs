namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record Result
{
    public sealed record Success : Result;

    public sealed record Unsuccess : Result;

    public sealed record SuccessfulStop : Result;

    public sealed record UnsuccessfulStop : Result;

    public sealed record SuccessfulAcceleration : Result;
}
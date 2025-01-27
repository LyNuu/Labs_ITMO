namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record Result
{
    public sealed record Success : Result;

    public sealed record Unsuccess : Result;
}
namespace Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

public abstract class CommandParse
{
    protected CommandParse? NextCommandParse { get; }

    protected CommandParse(CommandParse? nextCommandParse)
    {
        NextCommandParse = nextCommandParse;
    }

    public virtual string Parse(string command)
    {
        if (NextCommandParse != null)
            return NextCommandParse.Parse(command);
        return $"Unknown command: {command}";
    }
}
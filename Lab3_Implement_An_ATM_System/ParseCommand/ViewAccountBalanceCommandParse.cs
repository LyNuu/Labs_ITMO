using Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

namespace Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

public class ViewAccountBalanceCommandParse : CommandParse
{
    public ViewAccountBalanceCommandParse(CommandParse? nextCommandParse) : base(nextCommandParse)
    {
    }

    public override string Parse(string command)
    {
        string[] commandParts = command.Split(" ");
        if (commandParts[0] == "view")
        {
            var connectCommand = new ViewAccountBalanceCommand(commandParts[1], commandParts[2]);
            connectCommand.Execute();
        }

        return base.Parse(command);
    }
}
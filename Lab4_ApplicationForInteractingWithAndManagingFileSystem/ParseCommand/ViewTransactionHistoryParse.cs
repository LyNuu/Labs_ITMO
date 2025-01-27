using Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

namespace Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

public class ViewTransactionHistoryParse : CommandParse
{
    public ViewTransactionHistoryParse(CommandParse? nextCommandParse) : base(nextCommandParse)
    {
    }

    public override string Parse(string command)
    {
        string[] commandParts = command.Split(" ");
        if (commandParts[0] == "view_history")
        {
            var connectCommand = new ViewTransactionHistory(commandParts[1], commandParts[2]);
        }

        return base.Parse(command);
    }
}
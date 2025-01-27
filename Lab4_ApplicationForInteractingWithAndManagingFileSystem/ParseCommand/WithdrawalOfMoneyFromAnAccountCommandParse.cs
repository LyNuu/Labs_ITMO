using Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

namespace Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

public class WithdrawalOfMoneyFromAnAccountCommandParse : CommandParse
{
    public WithdrawalOfMoneyFromAnAccountCommandParse(CommandParse? nextCommandParse) : base(nextCommandParse)
    {
    }

    public override string Parse(string command)
    {
        string[] commandParts = command.Split(" ");
        if (commandParts[0] == "OfMoney")
        {
            var connectCommand = new WithdrawalOfMoneyFromAnAccountCommand(commandParts[1], commandParts[2], Convert.ToInt32(commandParts[3]));
            connectCommand.Execute();
        }

        return base.Parse(command);
    }
}
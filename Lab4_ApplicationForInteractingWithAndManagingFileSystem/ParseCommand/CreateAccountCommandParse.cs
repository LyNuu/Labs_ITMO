using Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

namespace Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

public class CreateAccountCommandParse : CommandParse
{
    public CreateAccountCommandParse(CommandParse? nextCommandParse) : base(nextCommandParse) { }

    public override string Parse(string command)
    {
        string[] commandParts = command.Split(" ");
        if (commandParts[0] == "create" && commandParts[3] == "local")
        {
            var createAccountCommand = new CreateAccountCommand(commandParts[1], commandParts[2]);
            createAccountCommand.Execute();
        }

        return base.Parse(command);
    }
}
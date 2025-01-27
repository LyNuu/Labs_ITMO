using Itmo.ObjectOrientedProgramming.Lab5.ParseCommand;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation;

public class Presentations
{
    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine() ?? throw new ArgumentNullException("Console.ReadLine()");
            if (input == "quit") return;
            var createCommand = new CreateAccountCommandParse(null);
            var viewAccountCommand = new ViewAccountBalanceCommandParse(createCommand);
            var viewTransactionHistoryCommand = new ViewTransactionHistoryParse(viewAccountCommand);
            var withdrawalOfMoneyCommand =
                new WithdrawalOfMoneyFromAnAccountCommandParse(viewTransactionHistoryCommand);
            var accountReplenishmentCommand = new AccountReplenishmentCommandParse(withdrawalOfMoneyCommand);
            createCommand = new CreateAccountCommandParse(accountReplenishmentCommand);
            createCommand.Parse(input);
        }
    }
}
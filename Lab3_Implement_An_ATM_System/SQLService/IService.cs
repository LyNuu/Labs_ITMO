using Itmo.ObjectOrientedProgramming.Lab5.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.SQLService;

public interface IService
{
    Task CreateAccountAsync(User user);

    Task<decimal> GetBalanceAsync(User user);

    Task WithdrawAsync(User user, decimal amount);

    Task DepositAsync(User user, decimal amount);

    Task<IEnumerable<string>> GetTransactionHistoryAsync(User user);
}
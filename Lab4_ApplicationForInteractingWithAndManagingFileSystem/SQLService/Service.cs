using Itmo.ObjectOrientedProgramming.Lab5.Models;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.SQLService;

public class Service : IService
{
    private readonly NpgsqlConnection? _connection;

    public Service(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public async Task CreateAccountAsync(User user)
    {
        string insertUserCommand = "INSERT INTO users (username, password, balance) VALUES (@username, @password, @balance)";

        using var command = new NpgsqlCommand(insertUserCommand, _connection);
        command.Parameters.AddWithValue("id");
        if (user.Username != null) command.Parameters.AddWithValue("username", user.Username);
        if (user.Password != null) command.Parameters.AddWithValue("password", user.Password);
        if (user.Balance != null) command.Parameters.AddWithValue("balance", user.Balance);

        await command.ExecuteNonQueryAsync().ConfigureAwait(false);
    }

    public async Task<decimal> GetBalanceAsync(User user)
    {
        string selectBalanceCommand = "SELECT balance FROM users WHERE user_id = @id;";

        using var command = new NpgsqlCommand(selectBalanceCommand, _connection);
        command.Parameters.AddWithValue("id");

        object? result = await command.ExecuteScalarAsync().ConfigureAwait(false);
        return result != null ? Convert.ToDecimal(result) : 0;
    }

    public async Task WithdrawAsync(User user, decimal amount)
    {
        string withdrawCommand = @"
                UPDATE users
                SET user_balance = user_balance - @amount
                WHERE user_id = @id AND user_balance >= @amount;
            ";

        using var command = new NpgsqlCommand(withdrawCommand, _connection);
        command.Parameters.AddWithValue("id");
        command.Parameters.AddWithValue("amount", amount);

        int rowsAffected = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        if (rowsAffected == 0)
        {
            throw new InvalidOperationException("Insufficient funds or user does not exist.");
        }
    }

    public async Task DepositAsync(User user, decimal amount)
    {
        string depositCommand = @"
                UPDATE users
                SET user_balance = user_balance + @amount
                WHERE user_id = @id;
            ";

        using var command = new NpgsqlCommand(depositCommand, _connection);
        command.Parameters.AddWithValue("id");
        command.Parameters.AddWithValue("amount", amount);

        int rowsAffected = await command.ExecuteNonQueryAsync().ConfigureAwait(false);

        if (rowsAffected == 0)
        {
            throw new InvalidOperationException("User does not exist.");
        }
    }

    public async Task<IEnumerable<string>> GetTransactionHistoryAsync(User user)
    {
        string transactionHistoryQuery = @"
                SELECT transaction_type, amount, transaction_date
                FROM transactions
                WHERE user_id = @id
                ORDER BY transaction_date DESC;
            ";

        using var command = new NpgsqlCommand(transactionHistoryQuery, _connection);
        command.Parameters.AddWithValue("id");

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        var transactions = new List<string>();

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            string transaction = $"{reader.GetString(0)} - {reader.GetDecimal(1)} - {reader.GetDateTime(2)}";
            transactions.Add(transaction);
        }

        return transactions;
    }
}

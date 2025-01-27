using Itmo.ObjectOrientedProgramming.Lab5.Models;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

public class AccountReplenishmentCommand : ICommand, IDisposable
{
    private readonly User? _user;
    private readonly SQLService.Service _service;
    private readonly int _money;
    private NpgsqlConnection? _connection;

    public AccountReplenishmentCommand(string? userName, string? password, int money)
    {
        if (_user != null) _user = _user with { Username = userName };
        if (_user != null) _user = _user with { Password = password };
        _connection = new NpgsqlConnection();
        _service = new SQLService.Service(_connection);
        _money = money;
    }

    public void Execute()
    {
        if (_user != null) _ = _service.DepositAsync(_user, _money);
    }

    public void Dispose()
    {
        if (_connection != null)
        {
            _connection.Dispose();
            _connection = null;
        }
    }
}
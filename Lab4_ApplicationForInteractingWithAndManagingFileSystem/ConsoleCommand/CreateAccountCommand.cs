using Itmo.ObjectOrientedProgramming.Lab5.Models;
using Npgsql;

namespace Itmo.ObjectOrientedProgramming.Lab5.ConsoleCommand;

public class CreateAccountCommand : ICommand, IDisposable
{
    private readonly User? _user;
    private readonly SQLService.Service _service;
    private NpgsqlConnection? _connection;

    public CreateAccountCommand(string? username, string password)
    {
        if (_user != null) _user = _user with { Username = username };
        if (_user != null) _user = _user with { Password = password };

        _connection = new NpgsqlConnection();
        _service = new SQLService.Service(_connection);
    }

    public void Execute()
    {
        if (_user != null) _ = _service.CreateAccountAsync(_user);
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
namespace Itmo.ObjectOrientedProgramming.Lab2.MyUser;

public class User : IUser
{
    public User(int id, string? username)
    {
        Id = id;
        Name = username;
    }

    public int Id { get; }

    public string? Name { get; set; }
}
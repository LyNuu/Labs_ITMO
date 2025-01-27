using Itmo.ObjectOrientedProgramming.Lab2.MySubject;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyRepository;

public class Repository : IRepository
{
    private readonly Collection<ISubject> _directories;

    public Repository()
    {
        _directories = new Collection<ISubject>();
        Subjects = new Collection<ISubject>();
    }

    public Collection<ISubject> Subjects { get; }

    public void Add(ISubject subject)
    {
        _directories.Add(subject);
        Subjects.Add(subject);
    }

    public Result Find(int id)
    {
        foreach (ISubject subject in _directories)
        {
            if (subject.Id == id)
            {
                return new Result.Success();
            }
        }

        return new Result.Unsuccess();
    }
}
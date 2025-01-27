using Itmo.ObjectOrientedProgramming.Lab2.MySubject;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyEducationlProgram;

public class EducationlProgram : IEducationlProgram
{
    public EducationlProgram(int id, string name, IUser manager)
    {
        Id = id;
        Name = name;
        Semesters = [1, 2, 3, 4, 5, 6, 7, 8];
        Manager = manager;
    }

    public int Id { get; }

    public string Name { get; }

    public int [] Semesters { get; }

    public IUser Manager { get; }

    public Collection<ISubject>? Subjects { get; }
}
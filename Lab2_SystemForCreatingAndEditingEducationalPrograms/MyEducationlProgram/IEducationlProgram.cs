using Itmo.ObjectOrientedProgramming.Lab2.MySubject;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyEducationlProgram;

public interface IEducationlProgram
{
    int Id { get; }

    string Name { get; }

    Collection<ISubject>? Subjects { get; }

    IUser Manager { get; }

    int [] Semesters { get; }
}
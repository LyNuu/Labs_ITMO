using Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MySubject;

public interface ISubject
{
    int Id { get; }

    int BaseId { get; }

    string? Name { get; }

    Collection<ILectureMaterials>? Lectures { get; }

    Collection<ILaboratoryWork>? Laboratories { get; }

    double? CountOfExams { get; }

    double? MinCountOfCredit { get; }

    int MaxPoints { get; }

    IUser Author { get; }

    Result ChangeName(string newName, IUser authorName);

    Result ChangeMinCountOfCredit(double newCountOfCredit, IUser author);

    Result ChangeMaxPoints(int newPoints, IUser author);

    ISubject Clone();
}
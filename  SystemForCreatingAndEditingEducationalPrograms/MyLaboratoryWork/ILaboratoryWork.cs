using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;

public interface ILaboratoryWork
{
    int Id { get; }

    int BaseId { get; }

    string? Name { get; }

    string? Description { get; }

    string? EvaluationCriteria { get; }

    int NumberOfPoints { get; }

    IUser? Author { get; }

    Result ChangeName(string newName, IUser authorName);

    Result ChangeDescription(string newDescription, IUser author);

    Result ChangeEvaluationCriteria(string newEvaluationCriteria, IUser author);

    ILaboratoryWork Clone();
}
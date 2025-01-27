using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;

public interface ILectureMaterials
{
    int Id { get; }

    int BaseId { get; }

    string? Name { get; }

    string? Description { get; }

    string? Content { get; }

    IUser? Author { get; }

    Result ChangeName(string newName, IUser authorName);

    Result ChangeDescription(string newDescription, IUser author);

    Result ChangeContent(string newEvaluationCriteria, IUser author);

    ILectureMaterials Clone();
}
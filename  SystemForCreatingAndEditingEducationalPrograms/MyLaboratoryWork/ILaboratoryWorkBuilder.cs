using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;

public interface ILaboratoryWorkBuilder
{
    ILaboratoryWorkBuilder WithId(int id);

    ILaboratoryWorkBuilder WithBaseId(int id);

    ILaboratoryWorkBuilder WithName(string? name);

    ILaboratoryWorkBuilder WithDescription(string? description);

    ILaboratoryWorkBuilder WithEvaluationCriteria(string? evaluationCriteria);

    ILaboratoryWorkBuilder WithNumberOfPoints(int numberOfPoints);

    ILaboratoryWorkBuilder WithAuthor(IUser author);

    ILaboratoryWork Build();
}
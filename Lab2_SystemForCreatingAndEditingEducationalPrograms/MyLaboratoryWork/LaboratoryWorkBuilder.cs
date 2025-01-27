using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;

public class LaboratoryWorkBuilder : ILaboratoryWorkBuilder
{
    private int? _baseId;

    private IUser? _author;

    private int? _id;

    private string? _name;

    private string? _description;

    private string? _evaluationCriteria;

    private int _numberOfPoints;

    public ILaboratoryWorkBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public ILaboratoryWorkBuilder WithBaseId(int id)
    {
        _baseId = id;

        return this;
    }

    public ILaboratoryWorkBuilder WithName(string? name)
    {
        _name = name;

        return this;
    }

    public ILaboratoryWorkBuilder WithDescription(string? description)
    {
        _description = description;

        return this;
    }

    public ILaboratoryWorkBuilder WithEvaluationCriteria(string? evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;

        return this;
    }

    public ILaboratoryWorkBuilder WithNumberOfPoints(int numberOfPoints)
    {
        _numberOfPoints = numberOfPoints;

        return this;
    }

    public ILaboratoryWorkBuilder WithAuthor(IUser author)
    {
        _author = author;

        return this;
    }

    public ILaboratoryWork Build()
    {
        return new LaboratoryWork(
            _id ?? throw new InvalidOperationException(),
            _baseId ?? throw new InvalidOperationException(),
            _name,
            _description,
            _evaluationCriteria,
            _numberOfPoints,
            _author ?? throw new InvalidOperationException());
    }
}
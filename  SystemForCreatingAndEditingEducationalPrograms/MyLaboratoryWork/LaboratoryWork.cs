using Itmo.ObjectOrientedProgramming.Lab2.MyIdGenerator;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;

public class LaboratoryWork : ILaboratoryWork
{
    public LaboratoryWork(
        int id,
        int baseId,
        string? name,
        string? description,
        string? evaluationCriteria,
        int numberOfPoints,
        IUser author)
    {
        Id = id;
        BaseId = baseId;
        Name = name;
        Description = description;
        EvaluationCriteria = evaluationCriteria;
        NumberOfPoints = numberOfPoints;
        Author = author;
    }

    public int Id { get; }

    public int BaseId { get; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public string? EvaluationCriteria { get; private set; }

    public int NumberOfPoints { get; }

    public IUser Author { get; }

    public ILaboratoryWork Clone()
    {
        ILaboratoryWork cloneLaboratoryWork = new LaboratoryWorkBuilder()
            .WithId(IdGenerator.GetId())
            .WithBaseId(Id)
            .WithName(Name)
            .WithDescription(Description)
            .WithAuthor(Author)
            .WithEvaluationCriteria(EvaluationCriteria)
            .WithNumberOfPoints(NumberOfPoints)
            .Build();

        return cloneLaboratoryWork;
    }

    public Result ChangeName(string newName, IUser authorName)
    {
        if (Author == authorName)
        {
            Name = newName;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }

    public Result ChangeDescription(string newDescription, IUser author)
    {
        if (Author == author)
        {
            Description = newDescription;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }

    public Result ChangeEvaluationCriteria(string newEvaluationCriteria, IUser author)
    {
        if (Author == author)
        {
            EvaluationCriteria = newEvaluationCriteria;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }
}
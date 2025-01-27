using Itmo.ObjectOrientedProgramming.Lab2.MyIdGenerator;
using Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MySubject;

public class Subject : ISubject
{
    public Subject(
        int id,
        int baseId,
        string? name,
        Collection<ILectureMaterials>? lectures,
        Collection<ILaboratoryWork>? laboratories,
        IUser author,
        int maxPoints,
        double? minPointsOfCredit,
        double? pointsOfExam)
    {
        Id = id;
        BaseId = baseId;
        Name = name;
        Lectures = lectures;
        Laboratories = laboratories;
        Author = author;
        MaxPoints = maxPoints;
        CountOfExams = pointsOfExam;
        MinCountOfCredit = minPointsOfCredit;
    }

    public double? CountOfExams { get; }

    public double? MinCountOfCredit { get; private set; }

    public int Id { get; }

    public int BaseId { get; }

    public string? Name { get; private set; }

    public int MaxPoints { get; private set; }

    public IUser Author { get; }

    public Collection<ILaboratoryWork>? Laboratories { get; }

    public Collection<ILectureMaterials>? Lectures { get; }

    public ISubject Clone()
    {
        var newSubject = new SubjectBuilder();
        newSubject.WithId(IdGenerator.GetId())
            .WithBaseId(Id)
            .WithName(Name)
            .WithAuthor(Author)
            .WithMaxPoints(MaxPoints)
            .WithExam(CountOfExams)
            .WithCredit(MinCountOfCredit);
        if (Lectures != null)
        {
            Lectures
                .ToList()
                .ForEach(element => newSubject.AddLectures(element));
        }

        if (Laboratories != null)
        {
            Laboratories
                .ToList()
                .ForEach(element => newSubject.AddLaboratories(element));
        }

        return newSubject.Build();
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

    public Result ChangeMinCountOfCredit(double newCountOfCredit, IUser author)
    {
        if (Author == author)
        {
            MinCountOfCredit = newCountOfCredit;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }

    public Result ChangeMaxPoints(int newPoints, IUser author)
    {
        if (Author == author)
        {
            MaxPoints = newPoints;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }
}
using Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.MySubject;

public class SubjectBuilder : ISubjectBuilder
{
    private readonly Collection<ILaboratoryWork>? _laboratories;

    private readonly Collection<ILectureMaterials>? _lectures;

    private int? _id;

    private double? _exam;

    private double? _credit;

    private int? _baseId;

    private int _maxPoints;

    private string? _name;

    private IUser? _author;

    public SubjectBuilder()
    {
        _lectures = new Collection<ILectureMaterials>();

        _laboratories = new Collection<ILaboratoryWork>();
    }

    public ISubjectBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public ISubjectBuilder WithBaseId(int id)
    {
        _baseId = id;

        return this;
    }

    public ISubjectBuilder WithName(string? name)
    {
        _name = name;

        return this;
    }

    public ISubjectBuilder WithMaxPoints(int maxPoints)
    {
        _maxPoints = maxPoints;

        return this;
    }

    public ISubjectBuilder AddLectures(ILectureMaterials lectures)
    {
        _lectures?.Add(lectures);

        return this;
    }

    public ISubjectBuilder AddLaboratories(ILaboratoryWork laboratories)
    {
        _laboratories?.Add(laboratories);

        return this;
    }

    public ISubjectBuilder WithAuthor(IUser author)
    {
         _author = author;

         return this;
    }

    public ISubjectBuilder WithExam(double? exam)
    {
        _exam = exam;

        return this;
    }

    public ISubjectBuilder WithCredit(double? credit)
    {
        _credit = credit;

        return this;
    }

    public ISubject Build()
    {
        return new Subject(
            _id ?? throw new InvalidOperationException(),
            _baseId ?? throw new InvalidOperationException(),
            _name,
            _lectures,
            _laboratories,
            _author ?? throw new InvalidOperationException(),
            _maxPoints,
            _credit,
            _credit == null ? _exam : null);
    }
}
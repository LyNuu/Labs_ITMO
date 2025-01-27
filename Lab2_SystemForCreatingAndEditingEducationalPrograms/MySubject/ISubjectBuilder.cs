using Itmo.ObjectOrientedProgramming.Lab2.MyLaboratoryWork;
using Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MySubject;

public interface ISubjectBuilder
{
    ISubjectBuilder WithId(int id);

    ISubjectBuilder WithBaseId(int id);

    ISubjectBuilder WithName(string? name);

    ISubjectBuilder AddLectures(ILectureMaterials lectures);

    ISubjectBuilder AddLaboratories(ILaboratoryWork laboratories);

    ISubjectBuilder WithExam(double? exam);

    ISubjectBuilder WithCredit(double? credit);

    ISubjectBuilder WithMaxPoints(int maxPoints);

    ISubjectBuilder WithAuthor(IUser author);

    ISubject Build();
}
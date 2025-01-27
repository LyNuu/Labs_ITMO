using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;

public interface ILecturesMaterialsBuilder
{
    ILecturesMaterialsBuilder WithId(int id);

    ILecturesMaterialsBuilder WithBaseId(int baseId);

    ILecturesMaterialsBuilder WithName(string? name);

    ILecturesMaterialsBuilder WithDescription(string? description);

    ILecturesMaterialsBuilder WithContent(string? content);

    ILecturesMaterialsBuilder WithAuthor(IUser? author);

    ILectureMaterials Build();
}
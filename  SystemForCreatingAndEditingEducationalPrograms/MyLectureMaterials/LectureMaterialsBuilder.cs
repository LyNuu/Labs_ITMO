using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;

public class LectureMaterialsBuilder : ILecturesMaterialsBuilder
{
    private IUser? _author;

    private int? _baseId;

    private int? _id;

    private string? _name;

    private string? _description;

    private string? _content;

    public ILecturesMaterialsBuilder WithId(int id)
    {
        _id = id;

        return this;
    }

    public ILecturesMaterialsBuilder WithBaseId(int baseId)
    {
        _baseId = baseId;

        return this;
    }

    public ILecturesMaterialsBuilder WithName(string? name)
    {
        _name = name;

        return this;
    }

    public ILecturesMaterialsBuilder WithDescription(string? description)
    {
        _description = description;

        return this;
    }

    public ILecturesMaterialsBuilder WithContent(string? content)
    {
        _content = content;

        return this;
    }

    public ILecturesMaterialsBuilder WithAuthor(IUser? author)
    {
         _author = author;

         return this;
    }

    public ILectureMaterials Build()
    {
        return new MyLectureMaterials.LectureMaterials(
                _id ?? throw new InvalidOperationException(),
                _baseId ?? throw new InvalidOperationException(),
                _name,
                _description,
                _content,
                _author ?? throw new InvalidOperationException());
    }
}
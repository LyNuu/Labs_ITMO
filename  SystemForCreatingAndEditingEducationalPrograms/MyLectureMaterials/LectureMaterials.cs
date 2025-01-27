using Itmo.ObjectOrientedProgramming.Lab2.MyIdGenerator;
using Itmo.ObjectOrientedProgramming.Lab2.MyUser;

namespace Itmo.ObjectOrientedProgramming.Lab2.MyLectureMaterials;

public class LectureMaterials : ILectureMaterials
{
    public LectureMaterials(
        int id,
        int baseId,
        string? name,
        string? description,
        string? content,
        IUser? author)
    {
        Id = id;
        BaseId = baseId;
        Name = name;
        Description = description;
        Content = content;
        Author = author;
    }

    public int Id { get; }

    public int BaseId { get; }

    public string? Name { get; private set; }

    public string? Description { get; private set; }

    public string? Content { get; private set; }

    public IUser? Author { get; }

    public ILectureMaterials Clone()
    {
        ILectureMaterials cloneLectureMaterials = new LectureMaterialsBuilder()
            .WithId(IdGenerator.GetId())
            .WithBaseId(Id)
            .WithName(Name)
            .WithDescription(Description)
            .WithContent(Content)
            .WithAuthor(Author)
            .Build();

        return cloneLectureMaterials;
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

    public Result ChangeContent(string newEvaluationCriteria, IUser author)
    {
        if (Author == author)
        {
            Content = newEvaluationCriteria;
            return new Result.Success();
        }

        return new Result.Unsuccess();
    }
}
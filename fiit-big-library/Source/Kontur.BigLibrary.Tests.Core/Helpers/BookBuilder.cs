using Kontur.BigLibrary.Service.Contracts;

namespace Kontur.BigLibrary.Tests.Core.Helpers;

public class BookBuilder
{
    private string? name;
    private string? author;
    private int? id;
    private int rubricId = 1;
    private int imageId = 1;
    private int? price;

    public BookBuilder WithName(string? name)
    {
        this.name = name;
        return this;
    }

    public BookBuilder WithAuthor(string author)
    {
        this.author = author;
        return this;
    }

    public BookBuilder WithId(int id)
    {
        this.id = id;
        return this;
    }
    
    public BookBuilder WithImage(int imageId)
    {
        this.imageId = imageId;
        return this;
    }

    public Book Build() => new()
    {
        Name = name ?? $"Default_name{IntGenerator.Get()}",
        Author = author ?? $"Default_author{IntGenerator.Get()}",
        Id = id ?? IntGenerator.Get(),
        Description = "",
        RubricId = rubricId,
        ImageId = imageId,
        Count = 1
    };
}
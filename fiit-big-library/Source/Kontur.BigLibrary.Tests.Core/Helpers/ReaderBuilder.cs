using Kontur.BigLibrary.Service.Contracts;

namespace Kontur.BigLibrary.Tests.Core.Helpers;

public class ReaderBuilder
{
    private int? id;
    private int? bookId;
    private string? userName;

    public ReaderBuilder WithName(string userName)
    {
        this.userName = userName;
        return this;
    }

    public ReaderBuilder WithBook(int bookId)
    {
        this.bookId = bookId;
        return this;
    }

    public ReaderBuilder WithId(int id)
    {
        this.id = id;
        return this;
    }

    public Reader Build() => new()
    {
        Id = id ?? IntGenerator.Get(),
        UserName = userName ?? $"Username {Guid.NewGuid()}",
        BookId = bookId ?? IntGenerator.Get()
    };
}
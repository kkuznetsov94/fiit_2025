using Kontur.BigLibrary.Service.Contracts;

namespace Kontur.BigLibrary.Tests.Core.Helpers;

public static class Books
{
    public static readonly Book EnglishBook = new BookBuilder()
        .WithName("Database Systems. The Complete Book")
        .WithAuthor("Hector Garcia-Molina, Jeffrey D.Ullman, Jennifer Widom")
        .Build();

    public static readonly Book RussianBook =
        new BookBuilder()
            .WithName("Вишневый сад").WithAuthor("Чехов")
            .Build();
}
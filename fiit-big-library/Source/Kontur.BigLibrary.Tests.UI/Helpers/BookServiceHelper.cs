using Kontur.BigLibrary.Service.Contracts;
using Kontur.BigLibrary.Tests.Core.ApiClients;
using Kontur.BigLibrary.Tests.Core.Helpers.StringGenerator;
using Newtonsoft.Json;

namespace Kontur.BigLibrary.Tests.UI.Helpers;

public static class BookServiceHelper
{
    private static BooksApiClient Client => new();

    public static Book CreateBook(string bookName, string author)
    {
        var token = AuthHelper.CreateUserAndGetTokenAsync(StringGenerator.GetEmail(), StringGenerator.GetValidPassword());
        var imageId =
            Client.CreateImage(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Helpers", "Files", "image.jpg"),
                token).Content;
        var book = new Book
        {
            Name = bookName,
            Description = $"DefaultDescription of {bookName}",
            Count = 1,
            Price = "123",
            Author = author,
            ImageId = int.Parse(imageId),
            RubricId = 1,
            IsDeleted = false,
        };
        var clientResult = Client.AddBookToLibrary(book, token);
        return JsonConvert.DeserializeObject<Book>(clientResult.Content!);
    }

    public static void SetBookAsBusy(int? bookId)
    {
        var userEmail = StringGenerator.GetEmail();
        var token = AuthHelper.CreateUserAndGetTokenAsync(userEmail, StringGenerator.GetValidPassword());

        Client.CheckoutBook(bookId.ToString(), userEmail, token);
    }
    
    public static void SetBookAsBusyByUser(int? bookId, string email, string password)
    {
        var token = AuthHelper.GetUserToken(email, password);
        Client.CheckoutBook(bookId.ToString(), email, token);
    }

    public static BookSummary[] GetAllBooks()
    {
        var token = AuthHelper.CreateUserAndGetTokenAsync(StringGenerator.GetEmail(), StringGenerator.GetValidPassword());
        var clientResult = Client.GetAllBooksFromLibrary(token);
        return JsonConvert.DeserializeObject<BookSummary[]>(clientResult.Content!);
    }
}
using Kontur.BigLibrary.Service.Contracts;
using Kontur.BigLibrary.Service.Models;
using Kontur.BigLibrary.Service.Services.AuthService;
using Kontur.BigLibrary.Tests.Core.ApiClients;
using Kontur.BigLibrary.Tests.Core.Helpers;
using Kontur.BigLibrary.Tests.Core.Helpers.StringGenerator;
using Newtonsoft.Json;

namespace Tests.ApiSystem;

public class BooksApiTestBase
{
    private static IAuthService authService;
    protected BooksApiClient booksApiClient;
    protected AuthApiClient authApiClient;
    
    public UserLoginModel GenerateUser()
    {
        return new UserLoginModel
        {
            Email = StringGenerator.GetEmail(),
            Password = StringGenerator.GetValidPassword()
        };
    }

    public Book CreateBook(string token)
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "image.jpg");
        var imageId = booksApiClient.CreateImage(path, token).Content;
        var book = new BookBuilder().WithName(StringGenerator.GetRandomString()).WithImage(int.Parse(imageId)).Build();
        
        var response = booksApiClient.AddBookToLibrary(book, token);
        return JsonConvert.DeserializeObject<Book>(response.Content!);
    }

    public (string email, string password, string token) CreateUser()
    {
        var user = GenerateUser();
        var registerResponse = authApiClient.RegisterUser(user.Email, user.Password);
        var token = JsonConvert.DeserializeObject<AuthResult>(registerResponse.Content).Token;
        return (user.Email, user.Password, token);
    }

    public BookSummary[] GetAllBooks(string token)
    {
       return JsonConvert.DeserializeObject<BookSummary[]>(booksApiClient.GetAllBooksFromLibrary(token).Content).ToArray();
    }
    
    public ReaderInQueue[]? GetReadersInQueue(string bookId, string token)
    {
        var readersQueueResponse = booksApiClient.GetReadersInQueue(bookId, token);
        return JsonConvert.DeserializeObject<ReaderInQueue[]>(readersQueueResponse.Content);
    }
    
    public Reader[]? GetBookReaders(string bookId, string token)
    {
        var readersQueueResponse = booksApiClient.GetBookReaders(bookId, token);
        return JsonConvert.DeserializeObject<Reader[]>(readersQueueResponse.Content);
    }
}
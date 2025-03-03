using System.Net;
using FluentAssertions;
using Kontur.BigLibrary.Service.Contracts;
using Kontur.BigLibrary.Tests.Core.ApiClients;
using Kontur.BigLibrary.Tests.Core.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Tests.ApiSystem;

public class BooksApiTests : BooksApiTestBase
{
    [OneTimeSetUp]
    public void SetUp()
    {
        authApiClient = new AuthApiClient();
        booksApiClient = new BooksApiClient();
    }

    [Test]
    public void AddNewBook_Correct_Success()
    {
        //Arrange
        var user = GenerateUser();
        var registerResponse = authApiClient.RegisterUser(user.Email, user.Password);
        var token = JsonConvert.DeserializeObject<AuthResult>(registerResponse.Content).Token;
        
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "image.jpg");
        var imageId = booksApiClient.CreateImage(path, token).Content;
        var book = new BookBuilder().WithImage(int.Parse(imageId)).Build();
        
        //Act
        var response = booksApiClient.AddBookToLibrary(book, token);
        
        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var savedBook = JsonConvert.DeserializeObject<Book>(response.Content!);
        savedBook.Should().BeEquivalentTo(book);
    }
}
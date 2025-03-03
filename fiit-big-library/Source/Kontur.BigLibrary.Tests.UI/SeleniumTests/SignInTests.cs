using FluentAssertions;
using Kontur.BigLibrary.Tests.Core.Helpers.StringGenerator;
using Kontur.BigLibrary.Tests.UI.Helpers;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages.MainPage;
using Kontur.BigLibrary.Tests.UI.SeleniumCore;
using NUnit.Framework;

namespace Kontur.BigLibrary.Tests.UI.SeleniumTests;

public class SignInTests : UiTestBase
{
    [Test]
    public async Task SignInWithRegistredUser_Test()
    {
        var userEmail = StringGenerator.GetEmail();
        var userPassword = StringGenerator.GetValidPassword();

        RegisterUser(userEmail,userPassword);
        //AuthHelper.CreateUserAndGetTokenAsync(userEmail, userPassword);

        var loginPage = driver.GoToPage<LoginPage>();
        loginPage.Email.SendKeys(userEmail);
        loginPage.Password.SendKeys(userPassword);
        var booksPage = loginPage.SignInButton.ClickWithRedirect<MainPage>(driver);

        booksPage.Books.IsDisplayed().Should().BeTrue();
        booksPage.Books.BookItems.Count.Should().BeGreaterThan(0);
    }

    public void RegisterUser(string email, string password)
    {
        var page = driver.GoToPage<RegisterPage>();
        page.EmailInput.SendKeys(email);
        page.PasswordInput.SendKeys(password);
        page.PasswordConfirmationInput.SendKeys(password);
        var booksPage = page.SubmitButton.ClickWithRedirect<MainPage>(driver);
        booksPage.CurrentUserMenu.Click();
        booksPage.LogOutButton.WaitVisible();
        booksPage.LogOutButton.Click();
    }
}
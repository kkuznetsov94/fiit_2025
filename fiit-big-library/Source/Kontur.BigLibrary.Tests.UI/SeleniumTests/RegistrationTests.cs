using FluentAssertions;
using Kontur.BigLibrary.Tests.Core.Helpers.StringGenerator;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages.MainPage;
using Kontur.BigLibrary.Tests.UI.SeleniumCore;
using NUnit.Framework;

namespace Kontur.BigLibrary.Tests.UI.SeleniumTests;

public class RegistrationTests : UiTestBase
{
    [Test]
    public void Registration_Test()
    {
        var userEmail = StringGenerator.GetEmail();
        var userPassword = StringGenerator.GetValidPassword();
        
        var page = driver.GoToPage<RegisterPage>();
        page.EmailInput.SendKeys(userEmail);
        page.PasswordInput.SendKeys(userPassword);
        page.PasswordConfirmationInput.SendKeys(userPassword);
        var booksPage = page.SubmitButton.ClickWithRedirect<MainPage>(driver);

        //Assert.That(false);
        booksPage.Books.IsDisplayed().Should().BeTrue();
        booksPage.Books.BookItems.Count.Should().BeGreaterThan(0);
    }
}
using FluentAssertions;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages;
using Kontur.BigLibrary.Tests.UI.SeleniumCore;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Kontur.BigLibrary.Tests.UI;
public class LectureExamplesTests
{
    [Test]
    public void UserRegistration_Success()
    {
        var validEmail = random.Next() + "@xx.com";
        var validPassword = "12345678Qwe!";
        
        //Arrange
        var driver = new ChromeDriver();

        driver.Navigate().GoToUrl("http://localhost:5000"); //переходим на сайт по заданному урлу

        //Act
        var registrationLink = driver.FindElement(By.CssSelector("a[href='/register']")); //нашли кнопку Регистрация
        registrationLink.Click(); //нажили на кнопку Регистрация
        
        var email = driver.FindElement(By.CssSelector("input.form-control[type=email]")); //нашли поле Электронная почта
        email.SendKeys(validEmail); //ввели валидный email в поле
        
        var password = driver.FindElements(By.CssSelector("input.form-control[type=password]")); //нашли поля для ввода пароля
        password[0].SendKeys(validPassword); //заполнили их
        password[1].SendKeys(validPassword);
        var registrationButton = driver.FindElement(By.CssSelector("button[type=submit]")); //нашли кнопку Зарегистрироваться
        registrationButton.Click(); //нажали на неё

        //Assert
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //задали максимальное время для неявного ожидания при поиске элемента
        var mainTitle = driver.FindElement(By.CssSelector("a[href='/']")); //нашли заголовок на новой странице
        mainTitle.Text.Should().Be("Библиотека"); //проверили, что заголовок отображается
        
        // var rubrics = new SelectElement(driver.FindElement(By.Id("bookRubricId")));
        // rubrics.SelectByIndex(0);
    }

    [Test]
    public void UserRegistration_WithPageObjectSuccess()
    {
        var validEmail = random.Next() + "@xx.com";
        var validPassword = "12345678Qwe!";
        
        var loginPage = driver.GoToPage<LoginPage>();
        var registrationPage = loginPage.RegistrationLink.ClickWithRedirect<RegisterPage>(driver);
        registrationPage.EmailInput.SendKeys(validEmail);
        registrationPage.PasswordInput.SendKeys(validPassword);
        registrationPage.PasswordConfirmationInput.SendKeys(validPassword);
        var mainPage = registrationPage.SubmitButton.ClickWithRedirect<RegisterPage>(driver);

        mainPage.WaitLoaded();
    }

    [Test]
    public void UserRegistration_WithPageObject_WhenEmailInvalid()
    {
        var invalidEmail = "qwe";
        var validPassword = "12345678Qwe!";

        var expectedValidationMessage = "Пожалуйста, введите корректный адрес электронной почты.";

        var loginPage = driver.GoToPage<LoginPage>();
        var registrationPage = loginPage.RegistrationLink.ClickWithRedirect<RegisterPage>(driver);
        registrationPage.EmailInput.SendKeys(invalidEmail);
        registrationPage.PasswordInput.SendKeys(validPassword);
        registrationPage.PasswordConfirmationInput.SendKeys(validPassword);
        registrationPage.SubmitButton.Click();

        Thread.Sleep(2000);
        registrationPage.EmailInput.ValidationMessage.Should().Be(expectedValidationMessage);


    }
    // Wait.For(()=> registrationPage.EmailInput.ValidationMessage == expectedValidationMessage, 
    // timeoutMessage:"Не дождались появления сообщения валидатора у поля Email", timeout:2000);

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit(); //закрыли браузер после того, как тест завершился
    }
    
    private ChromeDriver driver = new();
    private Random random = new();
}
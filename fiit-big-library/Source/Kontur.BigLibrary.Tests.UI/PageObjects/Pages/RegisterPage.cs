using Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Page;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.Pages;

public class RegisterPage : PageBase
{
    public RegisterPage(IWebDriver driver) : base(driver)
    {
    }

    public override string Url => "register";

    public override string Title => "Библиотека";

    public Button SubmitButton => Find<Button>(By.CssSelector("[type=submit]"));
    public ValidationInput EmailInput => Find<ValidationInput>(By.CssSelector("[data-tid=email-input]"));
    public ValidationInput PasswordInput => Find<ValidationInput>(By.CssSelector("[data-tid=password-first]"));
    public ValidationInput PasswordConfirmationInput => Find<ValidationInput>(By.CssSelector("[data-tid=password-confirmation]"));

    public Link LoginLink => Find<Link>(By.CssSelector("[href=/login]"));
    
    // public IWebElement SubmitButton => _driver.FindElement(By.CssSelector("[type=submit]"));
    // public IWebElement EmailInput => _driver.FindElement(By.CssSelector("[type=email]"));
    // public IWebElement PasswordInput => _driver.FindElement(By.CssSelector("[id=password]"));
    // public IWebElement PasswordConfirmationInput => _driver.FindElement(By.CssSelector("[id=password-confirmation]"));
    //
    // public IWebElement LoginLink => _driver.FindElement(By.CssSelector("[data-tid=password]"));

    public void FillAllFields(string email, string password)
    {
        EmailInput.SendKeys(email);
        PasswordInput.SendKeys(password);
        PasswordConfirmationInput.SendKeys(password);
    }
}
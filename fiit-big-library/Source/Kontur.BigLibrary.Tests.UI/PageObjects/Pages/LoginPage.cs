using Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Page;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.Pages;

public class LoginPage : PageBase
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    // public IWebElement Email => _driver.FindElement(By.CssSelector("[type=email]"));
    // public IWebElement Password => _driver.FindElement(By.CssSelector("[id=password]"));
    // public IWebElement SignInButton => _driver.FindElement(By.CssSelector("[type=submit]"));
    // public IWebElement RememberMeCheckbox => _driver.FindElement(By.CssSelector("[id='rememberMe']"));
    // public IWebElement RegistrationLink => _driver.FindElement(By.CssSelector("a[href='/register']"));
    public override string Url => "login";
    public override string Title => "Библиотека";

    public ValidationInput Email => Find<ValidationInput>(By.CssSelector("[data-tid='email']"));
    public ValidationInput Password => Find<ValidationInput>(By.CssSelector("[data-tid='password']"));
    public Button SignInButton => Find<Button>(By.CssSelector("[type=submit]"));
    public Checkbox RememberMeCheckbox => Find<Checkbox>(By.CssSelector("[id='rememberMe']"));
    public Link RegistrationLink => Find<Link>(By.CssSelector("a[href='/register']"));

}
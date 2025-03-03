using Kontur.BigLibrary.Tests.Core.ApiClients;
using Kontur.BigLibrary.Tests.UI.PageObjects.Pages;
using Kontur.BigLibrary.Tests.UI.SeleniumCore;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Kontur.BigLibrary.Tests.UI.Helpers;

public static class AuthHelper
{
    private static AuthApiClient ApiClient => new();


    public static string CreateUserAndGetTokenAsync(string email, string password)
    {
        var clientResult =  ApiClient.RegisterUser(email, password);
        if (!clientResult.IsSuccessful)
        {
            throw new Exception($"Ошибка при создании пользователя с почтой {email} и паролем {password}\n" +
                                $"{clientResult.Content}");
        }
        return JsonConvert.DeserializeObject<AuthResult>(clientResult.Content!)!.Token;
    }

    public static string GetUserToken(string email, string password)
    {
        var clientResult = ApiClient.LoginUser(email, password);
        if (!clientResult.IsSuccessful)
        {
            throw new Exception($"Ошибка при логине за  пользователя с почтой {email} и паролем {password}\n" +
                                $"{clientResult.Content}");
        }

        return  JsonConvert.DeserializeObject<AuthResult>(clientResult.Content!)!.Token;
    }
    
    public static void LoginUserAsync(string email, string password, IWebDriver driver)
    {
        var token = GetUserToken(email, password);

        //driver.Manage().Cookies.AddCookie(new Cookie());
        
        SetJwtToken(driver, token);
    }

    private static void SetJwtToken(IWebDriver driver, string token)
    {
        driver.GoToPage<LoginPage>();
        driver.ExecuteJavaScript($"localStorage.setItem('jwtToken','\"{token}\"');");
    }

    public static void CreateAndLoginUserAsync(string email, string password, IWebDriver driver)
    {
        CreateUserAndGetTokenAsync(email, password);
        LoginUserAsync(email, password, driver);
    }
}
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Page;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore;

public static class DriverExt
{
    public static TPage GoToPage<TPage>(this IWebDriver webDriver) where TPage : class, IPage
    {
        var page = (TPage)Activator.CreateInstance(typeof(TPage), webDriver)!;
        var url = $"{page.BaseUrl}/{page.Url}";
        webDriver.Navigate().GoToUrl(url);
        page.WaitLoaded();
        return page;
    }

    public static TPage ClickWithRedirect<TPage>(this IWebElement webElement, IWebDriver driver)
        where TPage : class, IPage
    {
        webElement.Click();
        var page = (TPage)Activator.CreateInstance(typeof(TPage), driver)!;
        page.WaitLoaded();
        return page;
    }
}
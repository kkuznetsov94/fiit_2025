using Kontur.BigLibrary.Tests.UI.Helpers;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Page;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public abstract class ControlBase : IControl
{
    public ISearchContext SearchContext { get; }
    public By Selector { get; }

    protected IWebElement _thisElement => SearchContext.FindElement(Selector);    
    
    protected ControlBase(ISearchContext searchContext, By selector)
    {
        SearchContext = searchContext;
        Selector = selector;
    }
    
    public void Click()
    {
        WaitVisible();
        _thisElement.Click();
    }

    public TPage ClickWithRedirect<TPage>(IWebDriver driver)
        where TPage : class, IPage
    {
        Click();
        var page = (TPage)Activator.CreateInstance(typeof(TPage), driver)!;
        page.WaitLoaded();
        return page;
    }

    public bool IsDisplayed() => _thisElement.Displayed;

    public bool IsDisabled() => !_thisElement.Enabled;

    public void WaitVisible(int timeout = 3000, string? timeoutMessage = null)
    {
        Wait.For(() =>
            {
                try
                {
                    return _thisElement.Displayed;
                }
                catch (Exception e)
                {
                    return false;
                }
            },
            timeout,
            timeoutMessage: timeoutMessage ?? "Не дождались видимости элемента ");
    }
    
    public void WaitText(string text, int timeout = 3000, string? timeoutMessage = null)
    {
        WaitVisible();
        Wait.For(() => _thisElement.Text.Equals(text), timeout,
            timeoutMessage: timeoutMessage ?? $"Ожидали, что элемент содержит текст '{text}', но получили '{_thisElement.Text}'");
    }

    public void WaitInvisible(int timeout = 3000, string? timeoutMessage = null)
    {
        Wait.For(() => !_thisElement.Displayed, timeout,
            timeoutMessage: timeoutMessage ?? "Не дождались видимости элемента ");
    }

    protected TControl Find<TControl>(By by) where TControl : class, IControl
    {
        return (TControl)Activator.CreateInstance(typeof(TControl), _thisElement, by);
    }

    protected List<TControl?> FindList<TControl>(By by)
        where TControl : class, IControl
    {
        var cssSelector = by.Criteria;
        var items = _thisElement.FindElements(by);
        var controls = Enumerable.Range(1, items.Count).Select(x => 
            (TControl)Activator.CreateInstance(typeof(TControl), _thisElement, By.CssSelector($"{cssSelector}:nth-child({x})")));
        return controls.ToList();
    }
}
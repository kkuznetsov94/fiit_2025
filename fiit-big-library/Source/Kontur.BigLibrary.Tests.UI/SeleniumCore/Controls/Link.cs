using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public class Link : ControlBase
{
    public Link(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
    }

    public string GetText => _thisElement.Text;
    public string Href => _thisElement.GetAttribute("href");
}
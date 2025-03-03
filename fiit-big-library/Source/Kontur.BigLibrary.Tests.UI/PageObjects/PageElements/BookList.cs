using Kontur.BigLibrary.Tests.UI.Helpers;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;

public class BookList : ControlBase
{
    public BookList(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
    }
    
    // public BookList(IWebElement thisElement) : base(thisElement)
    // {
    // }

    public List<BookItem?> BookItems => FindList<BookItem>(By.CssSelector("[data-tid^='bookItem-']"));
}
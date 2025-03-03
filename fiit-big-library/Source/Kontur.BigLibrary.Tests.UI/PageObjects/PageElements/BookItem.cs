using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;

public class BookItem : ControlBase
{
	public BookItem(ISearchContext searchContext, By selector) : base(searchContext, selector)
	{
	}
	
	public string Href => _thisElement.GetAttribute("href");
	public Label BookStatus => Find<Label>(By.CssSelector("data-tid='state-label'"));
}
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public class Button : ControlBase
{
	public Button(ISearchContext searchContext, By selector) : base(searchContext, selector)
	{
	}
	
	public string Text => _thisElement.Text;
}
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public class Checkbox : ControlBase
{
    public Checkbox(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
    }

    public bool IsChecked => _thisElement.Selected;

    public void SetChecked()
    {
        if (!IsChecked)
        {
            _thisElement.Click();
        }
    }
    public void SetUnChecked()
    {
        if (!IsChecked)
        {
            _thisElement.Click();
        }
    }
}
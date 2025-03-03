using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public class Input : ControlBase
{
    public Input(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
    }
    
    public virtual void SendKeys(string text) => _thisElement.SendKeys(text);
    public virtual string GetText() => _thisElement.Text;

    public virtual Label Validation => Find<Label>(By.CssSelector("data-tid='ValidationMessage'"));

    public virtual void WaitValidationError(string validationText)
    {
        Validation.WaitVisible();
        Validation.WaitText(validationText);
    }
}
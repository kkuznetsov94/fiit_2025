using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;

public class ValidationInput : ControlBase
{
    public ValidationInput(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
        
    }
    
    private Input Input => Find<Input>(By.CssSelector("[data-tid='input']"));

    private Label ValidationMessageLabel => Find<Label>(By.CssSelector("[data-tid='validation-message']"));

    public string ValidationMessage => ValidationMessageLabel.Text;
    public void SendKeys(string text) => Input.SendKeys(text);
}
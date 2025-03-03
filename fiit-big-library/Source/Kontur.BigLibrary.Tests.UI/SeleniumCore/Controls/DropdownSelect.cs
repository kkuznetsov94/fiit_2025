using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;

public class DropdownSelect : ControlBase
{
    public DropdownSelect(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
    }

    public IList<IWebElement> Options => _thisElement.FindElements(By.TagName("option"));

    public IWebElement SelectedOption
    {
        get
        {
            foreach (IWebElement option in this.Options)
            {
                if (option.Selected)
                    return option;
            }

            throw new NoSuchElementException("No option is selected");
        }
    }


    public void SelectByText(string text, bool partialMatch = false)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text), "text must not be null");

        _thisElement.Click();

        if (Options.Count > 0)
        {
            if (!partialMatch)
            {
                Options.First(x => x.Text == text).Click();
            }
            else
            {
                Options.First(x => x.Text.Contains(text)).Click();
            }
        }
    }
}
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;

public class LightboxBase : ControlBase
{
    public LightboxBase(ISearchContext searchContext, By selector) : base(searchContext, selector)
    {
        
    }
}
using Kontur.BigLibrary.Tests.UI.PageObjects.PageElements;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Controls;
using Kontur.BigLibrary.Tests.UI.SeleniumCore.Page;
using OpenQA.Selenium;

namespace Kontur.BigLibrary.Tests.UI.PageObjects.Pages.MainPage;

public class MainPage : PageBase
{
    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    public override string Url => "";
    public override string Title => "Список книг";

    public BookList Books => Find<BookList>(By.CssSelector("[data-tid='book-list']"));

    public Button CurrentUserMenu => Find<Button>(By.CssSelector("[data-tid='current_user_menu']"));

    public Button LogOutButton => Find<Button>(By.CssSelector("[data-tid='LogOut']"));

}
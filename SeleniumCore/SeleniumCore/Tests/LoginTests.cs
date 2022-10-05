using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers;

namespace SeleniumCore.Tests;

[TestClass]
public class LoginTests : BaseTest
{
    [DataRow(Constants.StandardUser)]
    [DataRow(Constants.ProblemUser)]
    //[DataRow(Constants.LockedOutUser)]
    [TestCategory("Login")]
    [DataTestMethod]
    public void UserCanLogInTest(string user)
    {
        GoTo(Configuration.Url);

        Pages.LoginPage.PerformLogin(user);

        Browser.WebDriver.Url.ShouldBe($"{Configuration.Url}inventory.html");
        Pages.InventoryPage.AreProductsDisplayed().ShouldBe(true);
    }

    [TestMethod]
    [TestCategory("Login")]
    public void UserCanNotLoginIfIsLockedOutTest()
    {
        GoTo(Configuration.Url);
        Pages.LoginPage.PerformLogin(Constants.LockedOutUser);
        Pages.LoginPage.IsErrorDisplayed().ShouldBe(true);
        Browser.WebDriver.Url.ShouldBe(Configuration.Url);
    }
}
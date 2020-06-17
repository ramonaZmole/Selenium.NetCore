using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers;

namespace SeleniumCore.Tests
{
    [TestClass]
    public class UserCanLogIn : BaseTest
    {
        [DataRow(Constants.StandardUser)]
        //[DataRow(Constants.ProblemUser)]
        //[DataRow(Constants.LockedOutUser)]
        [TestCategory("Login")]
        [TestMethod]
        public void UserCanLogInTest(string user)
        {
            Browser.Goto(Configuration.Url);

            Pages.LoginPage.PerformLogin(user);

            Browser.WebDriver.Url.Should().Be($"{Configuration.Url}inventory.html");
            Pages.InventoryPage.AreProductsDisplayed().Should().BeTrue();
        }
    }
}

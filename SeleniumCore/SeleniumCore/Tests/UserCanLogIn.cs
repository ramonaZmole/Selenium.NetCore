using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.BaseClasses;

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
            Browser.GoTo(Configuration.Url);

            Pages.LoginPage.PerformLogin(user);

            Browser.Driver.Url.Should().Be($"{Configuration.Url}inventory.html");
            Pages.InventoryPage.AreProductsDisplayed().Should().BeTrue();
        }
    }
}

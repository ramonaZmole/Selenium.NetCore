using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.BaseClasses;

namespace SeleniumCore.Tests
{
    [TestClass]
    public class UserCanLogIn : BaseTest
    {
        [TestMethod]
        public void UserCanLogInTest()
        {
            Browser.GoTo(Configuration.Url);

            Pages.LoginPage.PerformLogin(Constants.StandardUser, Constants.Password);

            //assert
            Browser.Driver.Url.Should().Be($"{Configuration.Url}inventory.html");
        }
    }
}

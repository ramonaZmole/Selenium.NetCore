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
            GoTo(Configuration.Url);

            LoginPage.PerformLogin(Constants.StandardUser, Constants.Password);

            Driver.Url.Should().Be($"{Configuration.Url}inventory.html");
        }
    }
}

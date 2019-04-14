using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCore.BaseClasses;
using SeleniumCore.Helpers;

namespace SeleniumCore.Tests
{
    [TestClass]
    public class UserCanLogIn : BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            SetupTest();
        }

        [TestMethod]
        public void UserCanLogInTest()
        {
            GoTo(Constants.Url);

            LoginPage.PerformLogin(Constants.StandardUser, Constants.Password);

            Driver.Url.Should().Be($"{Constants.Url}inventory.html");
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }

    }
}

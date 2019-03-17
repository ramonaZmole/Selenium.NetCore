using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCore
{
    [TestClass]
    public class UserCanLogIn
    {
        private IWebDriver _driver;

        [TestMethod]
        public void UserCanLogInTest()
        {
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputPath);

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButtonLocator = By.ClassName("btn_action");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(condition: ExpectedConditions.ElementIsVisible(loginButtonLocator));

            var userNameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            Assert.IsTrue(_driver.Url.Contains("https://www.saucedemo.com/inventory.html"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}

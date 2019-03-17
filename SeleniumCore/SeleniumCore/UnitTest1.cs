using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver _driver;

        [TestMethod]
        public void TestMethod1()
        {
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _driver = new ChromeDriver(outputPath);

            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginButton = _driver.FindElement(By.ClassName("btn_action"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }

    }
}

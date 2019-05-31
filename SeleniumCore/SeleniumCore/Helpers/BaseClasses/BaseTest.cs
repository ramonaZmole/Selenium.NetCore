using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCore.Pages;

namespace SeleniumCore.Helpers.BaseClasses
{
    public class BaseTest
    {
        protected static IWebDriver Driver;
        public LoginPage LoginPage;

        public AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();

        [TestInitialize]
        public void Setup()
        {
            StartDriver();
            InitializePages();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Quit();
        }

        private static void StartDriver()
        {
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(outputPath);
        }

        public void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        private void InitializePages()
        {
            LoginPage = new LoginPage(Driver);
        }

    }
}

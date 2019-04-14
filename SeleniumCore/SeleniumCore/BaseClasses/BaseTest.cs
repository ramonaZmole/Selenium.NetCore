using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCore.Pages;

namespace SeleniumCore.BaseClasses
{
    public class BaseTest
    {
        protected static IWebDriver Driver;
        public LoginPage LoginPage;

        public void SetupTest()
        {
            StartDriver();
            InitializePages();
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

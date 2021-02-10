using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium4
{
    [TestClass]
    public class UnitTest1
    {
        public static IWebDriver Driver;

        [TestInitialize]
        public void BeforeAll()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.google.com/");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Google", Driver.Title);
        }

        [TestCleanup]
        public void After()
        {
            Driver.Close();
        }
    }
}

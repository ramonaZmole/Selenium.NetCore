using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V87.Network;

namespace Selenium4
{
    [TestClass]
    public class UnitTest1
    {
        public static ChromeDriver Driver;

        [TestInitialize]
        public void BeforeAll()
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("My Store", Driver.Title);

            var searchInput = Driver.FindElement(By.Name("search_query"));
            var searchButton = Driver.FindElement(By.Name("submit_search"));
            searchInput.SendKeys("demo");
            searchButton.Click();

            searchInput = Driver.FindElement(By.Name("search_query"));
            searchInput.SendKeys(" demo 2");

            Driver.FindElement(RelativeBy.WithTagName("button").Above(By.Id("block_top_menu"))).Click();
            searchInput = Driver.FindElement(By.Name("search_query"));
            searchInput.SendKeys(" xxx");

            var session = Driver.CreateDevToolsSession();

            var blockedUrlSettings = new SetBlockedURLsCommandSettings();
            blockedUrlSettings.Urls = new string[] { "http://demos.bellatrix.solutions/wp-content/uploads/2018/04/440px-Launch_Vehicle__Verticalization__Proton-M-324x324.jpg" };
          //  session..SetBlockedURLs(blockedUrlSettings);
        }

        [TestCleanup]
        public void After()
        {
            Driver.Close();
        }
    }
}

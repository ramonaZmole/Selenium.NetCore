using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumCore.Helpers.BaseClasses
{
    public class BaseTest
    {
        public AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();

        [TestInitialize]
        public void Setup()
        {
            Browser.StartDriver();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Driver.Close();
            Browser.Driver.Quit();
        }
    }
}

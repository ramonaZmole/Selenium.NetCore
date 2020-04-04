using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumCore.Helpers.BaseClasses
{
    public class BaseTest
    {
        public AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void Setup()
        {
            Browser.StartDriver();
        }

        [TestCleanup]
        public void CleanUp()
        {
            //Browser.CheckLogs();
            if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
                ScreenShot.TakeAndAttachScreenShot(TestContext);

            Browser.Driver.Close();
            Browser.Driver.Quit();
        }
    }
}

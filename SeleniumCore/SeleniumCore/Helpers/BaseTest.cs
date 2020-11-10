using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers.Models;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]

namespace SeleniumCore.Helpers
{
    public class BaseTest : NsTestFrameworkUI.BaseTest
    {
        public AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();


        [TestInitialize]
        public void Before()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Constants.FullDownloadPath = Path.Combine(currentDirectory, "Download");
            Directory.CreateDirectory(Constants.FullDownloadPath);

            Browser.InitializeDriver(currentDirectory, !TestContext.TestName.Contains("Download"), Constants.FullDownloadPath);
            Tests.Pages.InitializePages();
        }
    }
}

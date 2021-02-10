using System;
using System.IO;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers.ExtentReport;
using SeleniumCore.Helpers.Models;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace SeleniumCore.Helpers
{
    [TestClass]
    public class BaseTest : NsTestFrameworkUI.BaseTest
    {
        public static AppSettings Configuration = ConfigurationRoot.GetApplicationConfiguration();
        private static readonly string CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [AssemblyInitialize]
        public static void BeforeAll(TestContext context)
        {
            ExtentService.InitializeExtentReport(CurrentDirectory);
        }

        [TestInitialize]
        public void Before()
        {
            Constants.FullDownloadPath = Path.Combine(CurrentDirectory, "Download");
            Directory.CreateDirectory(Constants.FullDownloadPath);

            var isHeadless = !TestContext.TestName.Contains("Download");
            Browser.InitializeDriver(isHeadless, Constants.FullDownloadPath);

            ExtentTestManager.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public override void After()
        {
            LogToExtentReport();
            Browser.Cleanup();
        }

        [AssemblyCleanup]
        public static void AfterAll()
        {
            ExtentService.Instance.Flush();
        }

        private void LogToExtentReport()
        {
            var fileName = $"{TestContext.TestName}_{DateTime.Now:h_mm_ss}.png";

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
                ExtentTestManager.GetTest().Pass("Test Passed");
            else
            {
                var mediaEntity = ExtentService.CaptureScreenShot(fileName);
                ExtentTestManager.GetTest().Fail("Test Failed", mediaEntity);
                ExtentTestManager.GetStep().Fail("Step Failed", mediaEntity);
            }
        }

        public void GoTo(string url)
        {
            Browser.GoTo(url);
            ExtentTestManager.GetTest().CreateStep($"{MethodBase.GetCurrentMethod().Name} {url}");
        }

        public void ShouldBe(string actual, string expected)
        {
            ExtentTestManager.GetTest().CreateStep($"{actual} should be {expected}");
            expected.Should().Be(actual);
        }
    }
}

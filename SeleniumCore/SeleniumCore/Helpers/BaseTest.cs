using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers.ExtentReport;
using SeleniumCore.Helpers.Models;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace SeleniumCore.Helpers;

[TestClass]
public class BaseTest
{
    public TestContext TestContext { get; set; }

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

        Browser.InitializeDriver(new DriverOptions
        {
            IsHeadless = !TestContext.TestName.Contains("Download"),
            DownloadDirectoryPath = Constants.FullDownloadPath,
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });

        ExtentTestManager.CreateTest(TestContext.TestName);
    }

    [TestCleanup]
    public void After()
    {
        if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
        {
            var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
            TestContext.AddResultFile(path);
        }
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

    public static void GoTo(string url)
    {
        //Browser.GoTo(url);
        Browser.WebDriver.Navigate().GoToUrl(url);
        ExtentTestManager.GetTest().CreateStep($"{MethodBase.GetCurrentMethod()?.Name} {url}");
    }

}
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;

namespace SeleniumCore.Helpers.ExtentReport;

public class ExtentService
{
    public static AventStack.ExtentReports.ExtentReports Instance { get; } = new();

    public static void InitializeExtentReport(string currentDirectory)
    {
        var reportsPath = Path.Combine(currentDirectory, "Reports");
        Directory.CreateDirectory(reportsPath);

        var htmlReporter = new ExtentHtmlReporter($"{reportsPath}\\index.html");
        htmlReporter.Config.Theme = Theme.Standard;
        Instance.AttachReporter(htmlReporter);
        Instance.AddSystemInfo("Host Name", "Selenium with .NetCore/.Net6");
        Instance.AddSystemInfo("Environment", ConfigurationRoot.GetApplicationConfiguration().Environment);
        Instance.AddSystemInfo("UserName", "Ramona Ionce (Zmole)");
    }

    public static MediaEntityModelProvider CaptureScreenShot(string screenShotName)
    {
        var screenshots = ((ITakesScreenshot)Browser.WebDriver).GetScreenshot().AsBase64EncodedString;
        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshots, screenShotName).Build();
    }
}
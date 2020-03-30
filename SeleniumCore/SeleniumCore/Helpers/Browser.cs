using System.IO;
using System.Reflection;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore.Helpers
{
    public static class Browser
    {
        public static IWebDriver Driver;

        public static void StartDriver()
        {
            var executingLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            Driver = new ChromeDriver(executingLocation, options);
        }

        public static void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        private static void AssertLogs(string value)
        {
            if (value == null) return;
            value.Should().NotContain("Cannot read property");
            value.Should().NotContain("Cannot set property");
            value.Should().NotContain("Internal Server Error");
            value.Should().NotContain("Error: [$compile:multidir]");
        }

        public static void CheckLogs()
        {
            var logs = Driver.Manage().Logs.GetLog(LogType.Browser);
            foreach (var log in logs)
                AssertLogs(log.Message);
        }
    }
}

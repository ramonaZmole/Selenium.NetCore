﻿using System.IO;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumCore.Helpers
{
    public static class Browser
    {
        public static IWebDriver Driver;

        public static void StartDriver()
        {
            var outputPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = new ChromeDriver(outputPath, options);
        }

        public static void GoTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
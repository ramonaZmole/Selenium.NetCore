using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCore.Helpers
{
    internal static class WaitHelper
    {
        private const int Milliseconds = 150;

        public static void WaitUntilElementIsVisible(this By element)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public static void ExplicitWait()
        {
            var startingTime = DateTime.Now;
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromMilliseconds(Milliseconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(Milliseconds)
            };
            wait.Until(d => DateTime.Now - startingTime - TimeSpan.FromMilliseconds(Milliseconds) > TimeSpan.Zero);
        }
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCore.Helpers
{
    internal static class WaitHelper
    {
        public static void WaitUntilElementIsVisible(this By element)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}

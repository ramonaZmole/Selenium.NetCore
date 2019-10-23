using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCore.Helpers.BaseClasses
{
    public class BasePage
    {
        public void WaitUntilElementIsVisible(By element)
        {
            var wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void SendKeys(By element, string values)
        {
            Browser.Driver.FindElement(element).SendKeys(values);
        }

        public void Submit(By element)
        {
            Browser.Driver.FindElement(element).Submit();
        }

    }
}

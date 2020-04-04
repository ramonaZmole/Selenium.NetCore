using System;
using OpenQA.Selenium;

namespace SeleniumCore.Helpers
{
    public static class PageHelper
    {
        public static void SendKeys(this By element, string values)
        {
            Browser.Driver.FindElement(element).SendKeys(values);
        }

        public static void Submit(this By element)
        {
            Browser.Driver.FindElement(element).Submit();
        }

        public static bool IsElementDisplayed(this By selector)
        {
            try
            {
                return Browser.Driver.FindElement(selector).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

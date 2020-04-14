using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;

namespace SeleniumCore.Helpers.Selenium
{
    internal static class PageHelper
    {
        public static void Submit(this By element)
        {
            Browser.Driver.FindElement(element).Submit();
        }
    }
}

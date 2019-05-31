using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCore.BaseClasses
{
    public class BasePage
    {
        protected static IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }

        public void Wait(By element)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void SendKeys(By element, string values)
        {
            Driver.FindElement(element).SendKeys(values);
        }

        public void Submit(By element)
        {
            Driver.FindElement(element).Submit();
        }

    }
}

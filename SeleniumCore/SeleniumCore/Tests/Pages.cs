using System;
using SeleniumCore.Helpers.Selenium;
using SeleniumCore.Pages;
using SeleniumExtras.PageObjects;

namespace SeleniumCore.Tests
{
    internal static class Pages
    {
        public static T InitPage<T>(T page)
        {
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        [ThreadStatic]
        public static LoginPage LoginPage;
        [ThreadStatic]
        public static InventoryPage InventoryPage;
        [ThreadStatic]
        public static ProductDetailsPage ProductDetailsPage;

        public static void InitializePages()
        {
            LoginPage = InitPage(new LoginPage());
            InventoryPage = InitPage(new InventoryPage());
            ProductDetailsPage = InitPage(new ProductDetailsPage());
        }
    }
}

using System;
using NsTestFrameworkUI.Pages;
using SeleniumCore.Pages;

namespace SeleniumCore.Tests
{
    internal static class Pages
    {
        [ThreadStatic]
        public static LoginPage LoginPage;
        [ThreadStatic]
        public static InventoryPage InventoryPage;
        [ThreadStatic]
        public static ProductDetailsPage ProductDetailsPage;

        public static void InitializePages()
        {
            LoginPage = PageHelpers.InitPage(new LoginPage());
            InventoryPage = PageHelpers.InitPage(new InventoryPage());
            ProductDetailsPage = PageHelpers.InitPage(new ProductDetailsPage());
        }
    }
}

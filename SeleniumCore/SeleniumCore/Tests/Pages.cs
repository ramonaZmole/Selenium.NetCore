﻿using SeleniumCore.Helpers;
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

        public static LoginPage LoginPage => InitPage(new LoginPage());
        public static InventoryPage InventoryPage => InitPage(new InventoryPage());
        public static ProductDetailsPage ProductDetailsPage => InitPage(new ProductDetailsPage());
    }
}

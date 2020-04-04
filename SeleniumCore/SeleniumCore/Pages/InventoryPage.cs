using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using SeleniumCore.Helpers;

namespace SeleniumCore.Pages
{
    public class InventoryPage
    {
        #region Selectors

        private readonly By _productsContainer = By.CssSelector(".inventory_container");

        #endregion

        public bool AreProductsDisplayed()
        {
            return _productsContainer.IsElementDisplayed();
        }
    }
}

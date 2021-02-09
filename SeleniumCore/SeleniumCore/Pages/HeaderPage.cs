﻿using System.Reflection;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Pages
{
    public abstract class HeaderPage
    {
        #region Selectors

        private readonly By _numberOfItemsInCart = By.CssSelector(".fa-layers-counter.shopping_cart_badge");

        #endregion

        public bool IsProductAddedToCart()
        {
            ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod().Name);
            return _numberOfItemsInCart.IsElementPresent();
        }
    }
}

using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace SeleniumCore.Pages
{
    public abstract class HeaderPage
    {
        #region Selectors

        private readonly By _numberOfItemsInCart = By.CssSelector(".fa-layers-counter.shopping_cart_badge");

        #endregion

        public bool IsProductAddedToCart()
        {
            return _numberOfItemsInCart.IsElementPresent();
        }
    }
}

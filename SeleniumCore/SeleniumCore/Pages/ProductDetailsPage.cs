using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers;

namespace SeleniumCore.Pages
{
    public class ProductDetailsPage : HeaderPage
    {
        #region Selectors

        private readonly By _addToCartButton = By.CssSelector(".inventory_details_price ~ button");
        private readonly By _price = By.CssSelector(".inventory_details_price");
        private readonly By _productName = By.CssSelector(".inventory_details_name");

        #endregion


        public bool IsAddToCartButtonDisplayed()
        {
            return _addToCartButton.IsElementPresent()
                   & GetAddToCartButtonText().Equals(Constants.AddToCart);
        }

        public void AddOrRemoveMaterialFromCart()
        {
            _addToCartButton.ActionClick();
            WaitHelpers.ExplicitWait();
        }

        public string GetAddToCartButtonText() => _addToCartButton.GetText();

        public string Price() => _price.GetText();

        public string ProductName() => _productName.GetText();

    }
}

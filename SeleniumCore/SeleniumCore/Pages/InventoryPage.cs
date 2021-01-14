using System.Linq;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers;

namespace SeleniumCore.Pages
{
    public class InventoryPage : HeaderPage
    {
        #region Selectors

        private readonly By _productsContainer = By.CssSelector(".inventory_container");
        private readonly By _addToCartButtons = By.CssSelector(".pricebar button");
        private readonly By _productNameList = By.CssSelector(".inventory_item_name");
        private readonly By _priceList = By.CssSelector(".inventory_item_price");

        #endregion

        public bool AreProductsDisplayed() => _productsContainer.IsElementPresent();

        public bool DoesAllButtonsContainAddToCartText()
        {
            return _addToCartButtons.GetElements()
                .Select(x => x.Text)
                .All(x => x.Equals(Constants.AddToCart));
        }

        public void AddOrRemoveProductFromCart(string name)
        {
            var productNameList = _productNameList.GetElements();
            var addToCartButtons = _addToCartButtons.GetElements();

            var productIndex = productNameList.IndexOf(productNameList.First(x => string.Equals(x.Text, name)));
            addToCartButtons[productIndex].Click();
            WaitHelpers.ExplicitWait();
        }

        public void GoToProductDetailsPage(int index)
        {
            _productNameList.GetElements()[index].Click();
        }

        public string GetPrice(int index)
        {
            return _priceList.GetElements()[index].Text;
        }

        public string GetProductName(in int materialIndex)
        {
            return _productNameList.GetElements()[materialIndex].Text;
        }
    }
}

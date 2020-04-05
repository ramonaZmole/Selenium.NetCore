using System.Linq;
using OpenQA.Selenium;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.Selenium;

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

        public bool AreProductsDisplayed()
        {
            return _productsContainer.IsElementDisplayed();
        }

        public bool DoesAllButtonsContainAddToCartText()
        {
            var addToCartButtons = Browser.Driver.FindElements(_addToCartButtons);
            return addToCartButtons.Select(x => x.Text)
                .All(x => x.Equals(Constants.AddToCart));
        }

        public void AddOrRemoveProductFromCart(string productName)
        {
            var productNameList = Browser.Driver.FindElements(_productNameList);
            var addToCartButtons = Browser.Driver.FindElements(_addToCartButtons);

            var productIndex = productNameList.IndexOf(productNameList.First(x => string.Equals(x.Text, productName)));
            addToCartButtons[productIndex].Click();
            WaitHelper.ExplicitWait();
        }

        public void GoToProductDetailsPage(int index)
        {
            var productNameList = Browser.Driver.FindElements(_productNameList);
            productNameList[index].Click();
        }

        public string GetPrice(int index)
        {
            var priceList = Browser.Driver.FindElements(_priceList);
            return priceList[index].Text;
        }

        public string GetProductName(in int materialIndex)
        {
            var productNameList = Browser.Driver.FindElements(_productNameList);
            return productNameList[materialIndex].Text;
        }
    }
}

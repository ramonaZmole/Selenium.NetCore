using System.Linq;
using System.Reflection;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Pages;

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
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
        return _productsContainer.IsElementPresent();
    }

    public bool DoesAllButtonsContainAddToCartText()
    {
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
        return _addToCartButtons.GetElements()
            .Select(x => x.Text)
            .All(x => x.Equals(Constants.AddToCart));
    }

    public void AddOrRemoveProductFromCart(string name)
    {
        var productNameList = _productNameList.GetElements();
        var addToCartButtons = _addToCartButtons.GetElements();

        var productIndex = productNameList.IndexOf(productNameList.First(x => string.Equals(x.Text, name)));

        var textButton = addToCartButtons[productIndex].Text.ToLower();
        if (textButton.Equals("add to cart"))
            ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Add To Cart");
        if (textButton.Equals("remove"))
            ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Remove from Cart");

        addToCartButtons[productIndex].Click();
        WaitHelpers.ExplicitWait();
    }

    public void GoToProductDetailsPage(int index)
    {
        _productNameList.GetElements()[index].Click();
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
    }

    public string GetPrice(int index)
    {
        return _priceList.GetElements()[index].Text;
    }

    public string GetProductName(in int materialIndex)
    {
        return _productNameList.GetElements()[materialIndex].Text;
    }

    public void AddToCartAllProductsThatAreUnder10Dollars()
    {
        var prices = _priceList.GetElements();
        var addToCartButtons = _addToCartButtons.GetElements();

        for (var i = 0; i < prices.Count; i++)
        {
            if (prices[i].Text.Trim('$').ConvertStringToDecimal() < 10)
                addToCartButtons[i].Click();
        }

        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
    }

    public int GetNumberOfProductsUnder10Dollar()
    {
        var prices = _priceList.GetElements();
        return prices.Select(x => x.Text.Trim('$')).Count(x => x.ConvertStringToDecimal() < 10);
    }
}
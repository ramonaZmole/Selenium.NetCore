using System.Reflection;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Pages;

public class ProductDetailsPage : HeaderPage
{
    #region Selectors

    private readonly By _addToCartButton = By.CssSelector(".inventory_details_price ~ button");
    private readonly By _price = By.CssSelector(".inventory_details_price");
    private readonly By _productName = By.CssSelector(".inventory_details_name");

    #endregion


    public bool IsAddToCartButtonDisplayed()
    {
        ExtentTestManager.GetTest().CreateNode(MethodBase.GetCurrentMethod()?.Name);
        return _addToCartButton.IsElementPresent()
               & GetAddToCartButtonText().Equals(Constants.AddToCart);
    }

    public void AddOrRemoveMaterialFromCart()
    {
        _addToCartButton.ActionClick();
        WaitHelpers.ExplicitWait();
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, "Add To Cart");
    }

    public string GetAddToCartButtonText()
    {
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
        return _addToCartButton.GetText();
    }

    public string Price()
    {
        var price = _price.GetText();
        ExtentTestManager.GetTest()
            .CreateStep($"Check {MethodBase.GetCurrentMethod()?.Name}", $"Get Product Price {price}");
        return price;
    }

    public string ProductName()
    {
        return _productName.GetText();
    }
}
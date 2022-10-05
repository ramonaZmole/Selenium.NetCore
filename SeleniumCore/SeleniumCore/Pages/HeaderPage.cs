using System.Reflection;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Pages;

public abstract class HeaderPage
{
    #region Selectors

    private readonly By _numberOfItemsInCart = By.CssSelector(".shopping_cart_badge");

    #endregion

    public bool IsProductAddedToCart()
    {
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
        return _numberOfItemsInCart.IsElementPresent();
    }

    public int GetNumberOfProductsAddedToCart()
    {
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name);
        return _numberOfItemsInCart.GetText().ConvertStringToInt32();
    }
}
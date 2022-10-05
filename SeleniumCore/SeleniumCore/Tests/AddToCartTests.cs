using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCore.Helpers;

namespace SeleniumCore.Tests;

[TestClass]
public class AddToCartTests : BaseTest
{
    [DataRow(Constants.StandardUser)]
    //[DataRow(Constants.ProblemUser)]
    [TestCategory("Add to cart")]
    [TestMethod, TestCategory("Add to cart")]
    public void ProductCanBeAddedAndBeRemovedFromCartFromHomepageTest(string user)
    {
        GoTo(Configuration.Url);

        Pages.LoginPage.PerformLogin(user);
        Pages.InventoryPage.DoesAllButtonsContainAddToCartText().ShouldBe(true);

        Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");

        Pages.InventoryPage.DoesAllButtonsContainAddToCartText().ShouldBe(false);
        Pages.InventoryPage.IsProductAddedToCart().ShouldBe(true);

        Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");
        Pages.InventoryPage.IsProductAddedToCart().ShouldBe(false);
        Pages.InventoryPage.DoesAllButtonsContainAddToCartText().ShouldBe(true);
    }

    [DataRow(Constants.StandardUser, 1)]
    // [DataRow(Constants.StandardUser, 2)]
    // [DataRow(Constants.StandardUser, 3)]
    //[DataRow(Constants.ProblemUser, 1)]
    //[DataRow(Constants.ProblemUser, 2)]
    //[DataRow(Constants.ProblemUser, 3)]
    [TestCategory("Add to cart")]
    [TestMethod]
    public void ProductCanBeAddedAndBeRemovedFromCartFromProductDetailsPageTest(string user, int materialIndex)
    {
        GoTo(Configuration.Url);

        Pages.LoginPage.PerformLogin(user);
        var price = Pages.InventoryPage.GetPrice(materialIndex);
        var productName = Pages.InventoryPage.GetProductName(materialIndex);

        Pages.InventoryPage.GoToProductDetailsPage(materialIndex);
        Pages.ProductDetailsPage.IsAddToCartButtonDisplayed().ShouldBe(true);
        //  ShouldBe(price, Pages.ProductDetailsPage.Price());
        Pages.ProductDetailsPage.Price().ShouldBe(price);
        Pages.ProductDetailsPage.ProductName().ShouldBe(productName);

        Pages.ProductDetailsPage.AddOrRemoveMaterialFromCart();
        Pages.ProductDetailsPage.IsProductAddedToCart().ShouldBe(true);
        Pages.ProductDetailsPage.GetAddToCartButtonText().ShouldBe("REMOVE");

        Pages.ProductDetailsPage.AddOrRemoveMaterialFromCart();
        Pages.ProductDetailsPage.IsProductAddedToCart().ShouldBe(false);
    }

    [TestCategory("Add to cart")]
    [TestMethod]
    public void AddToCartAllProductsUnder10DollarsTest()
    {
        GoTo(Configuration.Url);

        Pages.LoginPage.PerformLogin(Constants.StandardUser);
        Pages.InventoryPage.AddToCartAllProductsThatAreUnder10Dollars();
        Pages.InventoryPage.GetNumberOfProductsUnder10Dollar().ShouldBe(Pages.InventoryPage.GetNumberOfProductsAddedToCart());
    }
}
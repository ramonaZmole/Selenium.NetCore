using FluentAssertions;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.BaseClasses;

namespace SeleniumCore.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ProductCanBeRemovedFromCart : BaseTest
    {
        [DataRow(Constants.StandardUser)]
        //[DataRow(Constants.ProblemUser)]
        [TestMethod]
        public void ProductCanBeRemovedFromCartFromHomepageTest(string user)
        {
            Browser.GoTo(Configuration.Url);

            Pages.LoginPage.PerformLogin(user);
            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeTrue();

            Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");

            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeFalse();
            Pages.InventoryPage.IsProductAddedToCart().Should().BeTrue();

            Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");
            Pages.InventoryPage.IsProductAddedToCart().Should().BeFalse();
            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeTrue();
        }
    }
}

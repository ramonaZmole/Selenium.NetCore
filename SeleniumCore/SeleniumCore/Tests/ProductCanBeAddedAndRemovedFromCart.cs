﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.BaseClasses;

namespace SeleniumCore.Tests
{
    [TestClass]
    public class ProductCanBeAddedAndRemovedFromCart : BaseTest
    {
        [DataRow(Constants.StandardUser)]
        //[DataRow(Constants.ProblemUser)]
        [TestCategory("Add to cart")]
        [TestMethod, TestCategory("Add to cart")]
        public void ProductCanBeAddedAndBeRemovedFromCartFromHomepageTest(string user)
        {
            Browser.Goto(Configuration.Url);

            Pages.LoginPage.PerformLogin(user);
            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeTrue();

            Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");

            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeFalse();
            Pages.InventoryPage.IsProductAddedToCart().Should().BeTrue();

            Pages.InventoryPage.AddOrRemoveProductFromCart("Sauce Labs Bike Light");
            Pages.InventoryPage.IsProductAddedToCart().Should().BeFalse();
            Pages.InventoryPage.DoesAllButtonsContainAddToCartText().Should().BeTrue();
        }

        [DataRow(Constants.StandardUser, 1)]
        [DataRow(Constants.StandardUser, 2)]
        [DataRow(Constants.StandardUser, 3)]
        //[DataRow(Constants.ProblemUser, 1)]
        //[DataRow(Constants.ProblemUser, 2)]
        //[DataRow(Constants.ProblemUser, 3)]
        [TestCategory("Add to cart")]
        [TestMethod]
        public void ProductCanBeAddedAndBeRemovedFromCartFromProductDetailsPageTest(string user, int materialIndex)
        {
            Browser.Goto(Configuration.Url);

            Pages.LoginPage.PerformLogin(user);
            var price = Pages.InventoryPage.GetPrice(materialIndex);
            var productName = Pages.InventoryPage.GetProductName(materialIndex);

            Pages.InventoryPage.GoToProductDetailsPage(materialIndex);
            Pages.ProductDetailsPage.IsAddToCartButtonDisplayed().Should().BeTrue();
            Pages.ProductDetailsPage.Price().Should().Be(price);
            Pages.ProductDetailsPage.ProductName().Should().Be(productName);

            Pages.ProductDetailsPage.AddOrRemoveMaterialFromCart();
            Pages.ProductDetailsPage.IsProductAddedToCart().Should().BeTrue();
            Pages.ProductDetailsPage.GetAddToCartButtonText().Should().Be("REMOVE");

            Pages.ProductDetailsPage.AddOrRemoveMaterialFromCart();
            Pages.ProductDetailsPage.IsProductAddedToCart().Should().BeFalse();
        }
    }
}
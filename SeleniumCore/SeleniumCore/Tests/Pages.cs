using SeleniumCore.Pages;
using static NsTestFrameworkUI.Pages.PageHelpers;

namespace SeleniumCore.Tests;

internal static class Pages
{
    public static LoginPage LoginPage => InitPage(new LoginPage());
    public static InventoryPage InventoryPage => InitPage(new InventoryPage());
    public static ProductDetailsPage ProductDetailsPage => InitPage(new ProductDetailsPage());
}
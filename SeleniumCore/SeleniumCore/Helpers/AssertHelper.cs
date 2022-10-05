using FluentAssertions;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Helpers;

public static class AssertHelper
{
    public static void ShouldBe(this string actual, string expected)
    {
        ExtentTestManager.GetTest().CreateStep($"{actual} should be {expected}");
        actual.Should().Be(expected);
    }

    public static void ShouldBe(this int actual, int expected)
    {
        ExtentTestManager.GetTest().Info($"Actual: {actual} Expected: {expected}");
        actual.Should().Be(expected);
    }

    public static void ShouldBe(this bool actual, bool expected)
    {
        ExtentTestManager.GetStep().Info($"Actual: {actual} Expected: {expected}");
        actual.Should().Be(expected);
    }
}
using FluentAssertions;
using SeleniumCore.Helpers.ExtentReport;

namespace SeleniumCore.Helpers
{
    public static class AssertHelper
    {
        public static void ShouldBe(this string actual, string expected)
        {
            ExtentTestManager.GetTest().CreateStep($"{actual} should be {expected}");
            actual.Should().Be(expected);
        }

    }
}

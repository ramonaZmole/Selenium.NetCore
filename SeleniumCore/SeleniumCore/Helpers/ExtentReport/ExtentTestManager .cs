using System;
using AventStack.ExtentReports;

namespace SeleniumCore.Helpers.ExtentReport
{
    public static class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest _test;
        [ThreadStatic]
        private static ExtentTest _step;

        public static ExtentTest CreateTest(string testName, string description = null)
        {
            _test = ExtentService.Instance.CreateTest(testName, description);
            return _test;
        }

        public static ExtentTest CreateStep(this ExtentTest extentTest, string methodName, string description = null)
        {
            _step = extentTest.CreateNode(methodName, description);
            return _step;
        }

        public static ExtentTest GetTest() => _test;

        public static ExtentTest GetStep() => _step;

    }
}

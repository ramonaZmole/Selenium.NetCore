using System.Reflection;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using SeleniumCore.Helpers;
using SeleniumCore.Helpers.ExtentReport;
using SeleniumCore.Helpers.Selenium;

namespace SeleniumCore.Pages;

public class LoginPage
{
    #region Selectors

    private readonly By _userNameInput = By.Id("user-name");
    private readonly By _passwordInput = By.Id("password");
    private readonly By _loginButton = By.ClassName("btn_action");

    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    #endregion

    public void PerformLogin(string username)
    {
        _userNameInput.ActionSendKeys(username);
        _passwordInput.ActionSendKeys(Constants.Password);
        _loginButton.Submit();
        ExtentTestManager.GetTest().CreateStep(MethodBase.GetCurrentMethod()?.Name, $"Logged in with {username}");
    }

    public bool IsErrorDisplayed()
    {
        var message = _errorMessage.GetText();
        ExtentTestManager.GetTest().CreateStep($"{MethodBase.GetCurrentMethod()?.Name}");
        return message.Equals("Epic sadface: Sorry, this user has been locked out.");
    }
}
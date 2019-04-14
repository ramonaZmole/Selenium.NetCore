﻿using OpenQA.Selenium;

namespace SeleniumCore.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        #region Selectors

        private readonly By _userNameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.ClassName("btn_action");

        #endregion

        public void PerformLogin(string username, string password)
        {
            Wait(_loginButton);
            SendKeys(_userNameInput, username);
            SendKeys(_passwordInput, password);
            Submit(_loginButton);
        }
    }
}

using OpenQA.Selenium;
using SeleniumCore.Helpers;

namespace SeleniumCore.Pages
{
    public class LoginPage
    {
        #region Selectors

        private readonly By _userNameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.ClassName("btn_action");

        #endregion

        public void PerformLogin(string username)
        {
            _loginButton.WaitUntilElementIsVisible();
            _userNameInput.SendKeys(username);
            _passwordInput.SendKeys(Constants.Password);
            _loginButton.Submit();
        }
    }
}

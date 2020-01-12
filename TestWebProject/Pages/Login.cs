using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class Login
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://www.kostirpg.com/";
        [FindsBy(How = How.Id, Using = "email-login-input")] 
        private IWebElement _loginInput;
        
        [FindsBy(How = How.Id, Using = "password-login-input")] 
        private IWebElement _passwordInput;
        
        [FindsBy(How = How.ClassName, Using = "guest-btn")] 
        private IWebElement _guestButton;
        
        [FindsBy(How = How.ClassName, Using = "modal-btn-login")] 
        private IWebElement _submitButton;
        private static readonly string LOGIN_FORM = "login-form";
        public Login(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        public Login Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        public Login Guest()
        {
            _guestButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            if (wait.Until(d => _driver.FindElements(By.ClassName(LOGIN_FORM)).Count>0))
                return this;
            return null;
        }
        public Login FillUser(User user)
        {
            _loginInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);

            return this;
        }

        public void Submit()
        {
            _submitButton.Click();
        }

    }
}
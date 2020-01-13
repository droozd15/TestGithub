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
        private readonly string _url = @"https://app.planiro.com/ru/login";
        [FindsBy(How = How.Id, Using = "email-login-input")] 
        private IWebElement _loginInput;
        
        [FindsBy(How = How.Id, Using = "password-login-input")] 
        private IWebElement _passwordInput;
        
        [FindsBy(How = How.ClassName, Using = "submit")] 
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
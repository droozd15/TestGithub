using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Exception;
using Tests.Models;

namespace Tests.Pages
{
    public class Login
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://app.planiro.com/ru/login";
        [FindsBy(How = How.Id, Using = "signin_email")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "signin_password")] 
        private IWebElement _passwordInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[2]/form/div[5]/button")] 
        private IWebElement _submitButton;

        private static readonly string ERROR = "error";
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
            _emailInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);

            return this;
        }
        

        public Login Submit()
        {
            _submitButton.Click();
            
            if (_driver.FindElements(By.ClassName(ERROR)).Count > 0)
            {
                throw new MessageException("Данные для входа некорректны!");
            }
            return this;
        }

    }
}
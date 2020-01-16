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
        private readonly string _notifications = @"https://app.planiro.com/#/notifications";
        [FindsBy(How = How.Id, Using = "signin_email")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "signin_password")] 
        private IWebElement _passwordInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div/div[2]/form/div[5]/button")] 
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/aside/wm-side-left/div[2]/div/div/a[2]")] 
        private IWebElement _exitButton;
        
        private static readonly string ERROR = "error";
        private static readonly string USER_INFO = "side-block-user";
        private static readonly string SIDE_BAR = "side-left";
        
        private static readonly string  REGISTRATION = "modal-registration";
        public Login(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        public Login Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.Id("signin_email")).Count > 0))
            {
                return this;
            }
            return null;
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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.ClassName(USER_INFO)).Count > 0))
            {
                return this;
            }
            return null;
        }
        
        public Login ToNotifications()
        {
            _driver.Navigate().GoToUrl(_notifications);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.ClassName(SIDE_BAR)).Count > 0))
            {
                return this;
            }
            return null;
        }

        public Login Exit()
        {
            _exitButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.Id(REGISTRATION)).Count > 0))
            {
                return this;
            }
            return null;
        }
        
    }
}
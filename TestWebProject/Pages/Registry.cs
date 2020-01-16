using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Exception;
using Tests.Models;

namespace Tests.Pages
{
    public class RegistryPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://app.planiro.com/ru/login";
        
        [FindsBy(How = How.XPath, Using = "/html/body/header/div/div/div[2]/nav[2]/ul/li[2]/a")] 
        private IWebElement _registerButton;
            
        [FindsBy(How = How.Id, Using = "signup_name")] 
        private IWebElement _nameInput;
        
        [FindsBy(How = How.Id, Using = "signup_organization_name")] 
        private IWebElement _organizationInput;

        [FindsBy(How = How.Id, Using = "signup_email")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "signup_password")] 
        private IWebElement _passwordInput;
      
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div/div[2]/form/div[8]/button")] 
        private IWebElement _submitButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/main/div/div/div/form/div/div/div[2]/div[2]/a")] 
        private IWebElement _activityButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/aside/wm-side-left/div[2]/div/div/a[2]")] 
        private IWebElement _exitButton;        
       
        private static readonly string REGISTRATION = "registration";
        private static readonly string ERROR = "flash-error";
        private static readonly string USER_INFO = "side-block-user";
        public RegistryPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        
        public RegistryPages Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public RegistryPages FillUser(User user)
        {
            _nameInput.SendKeys(user.Name);
            _organizationInput.SendKeys(user.Organization);
            _emailInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);
            
            return this;
        }

        public RegistryPages Submit()
        {
            _submitButton.Click();
            if (_driver.FindElements(By.ClassName(REGISTRATION)).Count > 0)
            {
                throw new MessageException("Данные для входа некорректны!");
            }
           
            return this;
        }

        public RegistryPages Guest()
        {
            _registerButton.Click();
            //WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            //if (wait.Until(d => _driver.FindElements(By.ClassName(REGISTRY)).Count>0))
                return this;
            //return null;
        }
        public RegistryPages Activity()
        {
            _activityButton.Click();
            return this;
        }
        
        public RegistryPages Clear()
        {
            _nameInput.Clear();
            _organizationInput.Clear();
            _emailInput.Clear();
            _passwordInput.Clear();
            return this;
        }
        
        public RegistryPages Exit()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.ClassName(USER_INFO)).Count > 0))
            {
                _exitButton.Click();
                return this;
            }
            
            return this;
        }

    }
}
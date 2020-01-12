using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class RegistryPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://www.kostirpg.com/";
        
        [FindsBy(How = How.ClassName, Using = "guest-btn")] 
        private IWebElement _guestButton;
            
        [FindsBy(How = How.Id, Using = "name-registration-input")] 
        private IWebElement _nameInput;
        
        [FindsBy(How = How.Id, Using = "emailRegistrationInput")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "password-registration-input")] 
        private IWebElement _passwordInput;
      
        [FindsBy(How = How.ClassName, Using = "modal-btn-register")] 
        private IWebElement _submitButton;
        
       
        private static readonly string REGISTRY = "modal-action-register";
        private static readonly string ERROR = "flash-error";
        
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
            _nameInput.SendKeys(user.Login);
            _emailInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);
            
            return this;
        }

        public void Submit()
        {
            _submitButton.Click();
        }

        public RegistryPages Guest()
        {
            _guestButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            if (wait.Until(d => _driver.FindElements(By.ClassName(REGISTRY)).Count>0))
                return this;
            return null;
        }
        public RegistryPages Registry()
        {
             _driver.FindElement(By.ClassName(REGISTRY)).Click();
             return this;
        }
        
    }
}
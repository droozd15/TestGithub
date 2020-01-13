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
            _nameInput.SendKeys(user.Name);
            _organizationInput.SendKeys(user.Organization);
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
        
    }
}
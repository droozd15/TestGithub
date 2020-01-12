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
        private readonly string _url = @"https://github.com/";
        
        [FindsBy(How = How.Id, Using = "user[login]")] 
        private IWebElement _loginInput;
        
        [FindsBy(How = How.Id, Using = "user[email]")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "user[password]")] 
        private IWebElement _passwordInput;
      
        [FindsBy(How = How.ClassName, Using = "btn-primary-mktg")] 
        private IWebElement _submitButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/div/div[2]/div[2]/a[1]")] 
        private IWebElement _signInButton;
        
        private static readonly string PROBLEMS = "Problems with creating account";
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
            _loginInput.SendKeys(user.Login);
            _emailInput.SendKeys(user.Email);
            _passwordInput.SendKeys(user.Password);
            
            return this;
        }

        public void Submit()
        {
            _submitButton.Click();
            try
            {
                if (_driver.FindElement(By.ClassName(ERROR)) != null)
                {
                    throw new System.Exception("has error");
                }
            }
            catch (System.Exception e)
            {
                
            }

        }

        public Login SignIn()
        {
            _signInButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            if (wait.Until(d => _driver.FindElements(By.Id("login_field")).Count>0))
                return new Login(_driver);
            return null;
        }
    }
}
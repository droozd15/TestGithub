using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class Login
    {
        private readonly IWebDriver _driver;
        [FindsBy(How = How.Id, Using = "login_field")] 
        private IWebElement _loginInput;
        
        [FindsBy(How = How.Id, Using = "password")] 
        private IWebElement _passwordInput;
        
        
        [FindsBy(How = How.ClassName, Using = "btn-primary")] 
        private IWebElement _submitButton;

        public Login(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
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
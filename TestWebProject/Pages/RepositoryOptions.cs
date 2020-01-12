using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Tests.Pages
{
    public class RepositoryOptionsPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://github.com/droozd15/";

        [FindsBy(How = How.XPath,
            Using = "/html/body/div[4]/div/main/div[3]/div/div/div[2]/div/div[8]/ul/li[1]/details/summary")]
        private IWebElement _privacyButton;

        [FindsBy(How = How.ClassName, Using = "input-block")]
        private IWebElement _confirmInput;

        [FindsBy(How = How.ClassName, Using = "btn-danger")]
        private IWebElement _confirmButton;
        
        [FindsBy(How = How.Id, Using = "sudo_password")]
        private IWebElement _passwordInput;
        //testRepository/settings

        public RepositoryOptionsPages ToRepositoryOptions(string repository)
        {
            _driver.Navigate().GoToUrl(_url + repository);
            return this;
        }

        public RepositoryOptionsPages Privacy()
        {
            _privacyButton.Click();
            return this;
        }

        public void FillConfirm(string confirm)
        {
            _confirmInput.SendKeys(confirm);
        }
        public void FillPassword(string password)
        {
            _passwordInput.SendKeys(password);
        }
        public RepositoryOptionsPages Confirm()
        {
            _confirmButton.Click();
            return this;
        }
    }
}
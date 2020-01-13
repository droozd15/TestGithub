using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class ProjectPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://app.planiro.com/#/projects";

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/main/div/div[1]/div[1]/div/div[1]/div/div[1]/a")]
        private IWebElement _createButton;

        public ProjectPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ProjectPages Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public ProjectPages CreateProject()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            if (wait.Until(d => _driver.FindElements(By.XPath("/html/body/div[3]/main/div/div[1]/div[1]/div/div[1]/div/div[1]/a")).Count > 0))
            {
                _createButton.Click();
                return this;
            }
            return null;
        }
    }
}
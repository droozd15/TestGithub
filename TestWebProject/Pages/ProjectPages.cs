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
            
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[1]/div/div[1]/div/form/div[1]/input")]
        private IWebElement _titleInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[1]/div/div[1]/div/form/div[2]/textarea")]
        private IWebElement _descriptionInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[1]/div/div[1]/div/form/div[7]/button")]
        private IWebElement _submitButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div[1]/div[1]/div[1]/div/div[2]/div[3]/a[2]")]
        private IWebElement _createTaskButton;

        
        private static readonly string PROJECT_CONTENT = "main-content";
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
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.Id(PROJECT_CONTENT)).Count > 0))
            {
                _createButton.Click();
                return this;
            }
            return null;
        }
        
        public ProjectPages FillProject(Project project)
        {
            _titleInput.SendKeys(project.Title);
            _descriptionInput.SendKeys(project.Description);
           
            return this;
        }
        public TaskPages Submit()
        {
            _submitButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            if (wait.Until(d => _driver.FindElements(By.ClassName("empty-section")).Count > 0))
            {
                return new TaskPages(_driver);
            }
            return null;
        }
    }
}
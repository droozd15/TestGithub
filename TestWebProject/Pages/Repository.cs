using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    ///html/body/div[4]/div/aside[1]/div[2]/div/div/h2/a
    public class RepositoryPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://github.com/new/";
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/aside[1]/div[2]/div/div/h2/a")] 
        private IWebElement _newButton;
        
        [FindsBy(How = How.ClassName, Using = "first-in-line")] 
        private IWebElement _createButton;
        
        [FindsBy(How = How.Id, Using = "repository_name")] 
        private IWebElement _repositoryNameInput;
        
        [FindsBy(How = How.Id, Using = "repository_description")] 
        private IWebElement _repositoryDescriptionInput;
        
        public RepositoryPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        
        public RepositoryPages Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        public RepositoryPages New()
        {
            _newButton.Click();
            return this;
        }
        public RepositoryPages Create()
        {
            _createButton.Click();
            return this;
        }
        public RepositoryPages FillRepository(Repository repository)
        {
            _repositoryNameInput.SendKeys(repository.Name);
            _repositoryDescriptionInput.SendKeys(repository.Description);
            
            return this;
        }
    }
}
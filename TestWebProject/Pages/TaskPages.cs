using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class TaskPages
    {
        private readonly IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div[1]/div[1]/div[1]/div/div[2]/div[3]/a[1]")]
        private IWebElement _createButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[1]/div[1]/div/div[4]/form/div[8]/div/button[1]")]
        private IWebElement _submitButton;
        
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement _titleInput;
        
        [FindsBy(How = How.ClassName, Using = "pen-placeholder")]
        private IWebElement _descriptionInput;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[1]/div[1]/div/div[4]/form/div[4]/div/input")]
        private IWebElement _fileInput;
        
        private static readonly string ERROR = "error-message";
        public TaskPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        public TaskPages CreateTask()
        {
            _createButton.Click();
            return this;
        }
        public TaskPages FillTask(Task task)
        {
            _titleInput.SendKeys(task.Title);
            _descriptionInput.SendKeys(task.Description);
           _fileInput.SendKeys(task.FilePath);
            
            return this;
        }
        public TaskPages Submit()
        {
            _submitButton.Click();
            return this;
        }
    }
}
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://www.kostirpg.com/";
        
        [FindsBy(How = How.ClassName, Using = "slick-read_btn")] 
        private IWebElement _readButton;
        
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        public HomePage Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        public HomePage Read()
        {
            _readButton.Click();
            return this;
        }
    }
}
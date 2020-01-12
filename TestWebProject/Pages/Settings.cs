using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class SettingsPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://github.com/settings/profile/";
        
        [FindsBy(How = How.Id, Using = "user_profile_name")] 
        private IWebElement _nameInput;

        [FindsBy(How = How.Id, Using = "user_profile_name")] 
        private IWebElement _emailInput;

        [FindsBy(How = How.Id, Using = "user_profile_bio")] 
        private IWebElement _bioInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[2]/div[2]/div[2]/dl/dd/div/details/details-menu")] 
        private IWebElement _uploadPhoto;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/main/div/div[2]/div[2]/div[2]/dl/dd/div/details/summary/div")] 
        private IWebElement _editButton;

        public SettingsPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        
        public SettingsPages Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        
        public SettingsPages FillUser(User user)
        {
            _nameInput.SendKeys(user.Name);
            //_emailInput.SendKeys(user.Email);
            _bioInput.SendKeys(user.Bio);
            _uploadPhoto.SendKeys(user.FilePath);
//            _avatar.SendKeys(user.FilePath);
            
            return this;
        }
        public SettingsPages Edit()
        {
            _editButton.Click();
            _uploadPhoto.Click();
            return this;
        }
    }
}
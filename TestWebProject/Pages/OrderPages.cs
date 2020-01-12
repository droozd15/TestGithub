using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class OrderPages
    {
        [FindsBy(How = How.ClassName, Using = "checkout-continue")] 
        private IWebElement _continueButton;
        
        [FindsBy(How = How.Id, Using = "name-checkout-input")] 
        private IWebElement _nameInput;
        
        [FindsBy(How = How.Id, Using = "surname-checkout-input")] 
        private IWebElement _surnameInput;

        [FindsBy(How = How.Id, Using = "address-checkout-input")] 
        private IWebElement _addressInput;
        
        [FindsBy(How = How.Id, Using = "zip-checkout-input")] 
        private IWebElement _zipInput;
        
        [FindsBy(How = How.Id, Using = "country-checkout-select")] 
        private IWebElement _country;
        
        [FindsBy(How = How.Id, Using = "city-checkout-input")] 
        private IWebElement _cityInput;
        
        [FindsBy(How = How.Id, Using = "email-checkout-input")] 
        private IWebElement _emailInput;
        
        [FindsBy(How = How.Id, Using = "phone-checkout-input")] 
        private IWebElement _phoneInput;
        
        [FindsBy(How = How.Id, Using = "agreement")] 
        private IWebElement _agreeCheckbox;
        
        public OrderPages Continue()
        {
            _continueButton.Click();
            return this;
        }
        
        public OrderPages FillAddress(Address address)
        {
            _nameInput.SendKeys(address.Name);
            _surnameInput.SendKeys(address.Surname);
            _addressInput.SendKeys(address.Street);
            _zipInput.SendKeys(address.Index);
            _cityInput.SendKeys(address.City);
            _emailInput.SendKeys(address.Email);
           _phoneInput.SendKeys(address.Surname);
            return this;
        }
    }
}
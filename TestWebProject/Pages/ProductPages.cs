using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Tests.Models;

namespace Tests.Pages
{
    public class ProductPages
    {
        private readonly IWebDriver _driver;
        private readonly string _url = @"https://www.kostirpg.com/magazin";
        
        
        [FindsBy(How = How.ClassName, Using = "add_to_cart-btn")] 
        private IWebElement _cartButton;
        
        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div[2]/div[1]/div[1]/a")] 
        private IWebElement _productRef;
        
        [FindsBy(How = How.ClassName, Using = "minicart")] 
        private IWebElement _minicartButton;
        
        [FindsBy(How = How.ClassName, Using = "checkout-continue")] 
        private IWebElement _continueButton;
        
        private static readonly string CART_BUTTON = "add_to_cart-btn";
        public ProductPages(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver,this);
        }
        public ProductPages Navigate()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }
        public ProductPages AddProduct()
        {
            _productRef.Click();
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
            
            if (wait.Until(d => _driver.FindElements(By.ClassName(CART_BUTTON)).Count>0))
                return this;
            return null;
        }

        public ProductPages Cart()
        {
            _cartButton.Click();
            return this;
        }
        public ProductPages ToCart()
        {
            _minicartButton.Click();
            return this;
        }

        public OrderPages Continue()
        {
            _continueButton.Click();
            return new OrderPages();
        }
        
    }
}
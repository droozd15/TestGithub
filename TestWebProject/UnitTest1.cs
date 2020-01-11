using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Models;
using Tests.Pages;

namespace Tests
{
    public class Tests
    {
        private IWebDriver _chromeDriver;
        
        [SetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver("C:/Users/Anna Zanovskaya/RiderProjects/TestWebProject/TestWebProject/bin/Debug/netcoreapp2.1");
        }

        [Test]
        public void Test1()
        {
           Registry registryPage = new Registry(_chromeDriver);
           User user = User.TestUser();
           
               //registerPage.Navigate().FillUser(user).Submit();
            registryPage.Navigate().FillUser(user).Submit();
        }
        
        [Test]
        public void TestSignIn()
        {
            //HeaderMenu-link
            Registry registryPage = new Registry(_chromeDriver);
            User user = User.MyAkk();
           
            //registerPage.Navigate().FillUser(user).Submit();
            registryPage.Navigate().SignIn().FillUser(user).Submit();
        }
    }
}
using System;
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

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //            _chromeDriver.Quit();
        }        
       
        
        [Test]
        public void SuccesfulRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();
           
            registryPage.Navigate().FillUser(user).Submit();
        }
        
        [Test]
        public void FailRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();
            user.Email = "";
            registryPage.Navigate().FillUser(user).Submit();
            
            user = User.GetRandomUserForRegistration();
            user.Email = "test@ui";
            registryPage.Navigate().FillUser(user).Submit();
            
            user = User.GetRandomUserForRegistration();
            user.Login = "";
            registryPage.Navigate().FillUser(user).Submit();
        }
        
        [Test]
        public void SuccesfulTestSignIn()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.ValidUser();
            
            registryPage.Navigate().SignIn().FillUser(user).Submit();
        }
        
        [Test]
        public void FailTestSignIn()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User  user = User.GetRandomUserForRegistration();

            registryPage.Navigate().SignIn().FillUser(user).Submit();
        }

        [Test]
        public void CreateNewRepository()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.ValidUser();
            
            registryPage.Navigate().SignIn().FillUser(user).Submit();
            
            RepositoryPages repositoryPages = new RepositoryPages(_chromeDriver);
            Repository repository = Repository.GetRandomRepository();

            repositoryPages.New().FillRepository(repository).Create();
        }
        [Test]
        public void CreateExistRepository()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.ValidUser();
            
            registryPage.Navigate().SignIn().FillUser(user).Submit();
            
            RepositoryPages repositoryPages = new RepositoryPages(_chromeDriver);
            Repository repository = Repository.GetExistRepository();

            repositoryPages.New().FillRepository(repository).Create();
        }
    }
}
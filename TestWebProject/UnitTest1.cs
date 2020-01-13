using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Helpers;
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
         //   _chromeDriver.Quit();
        }        
       
        [Test]
        public void SuccesfulRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();

            registryPage.Navigate().Guest().FillUser(user).Submit();
        }   
     
        
        [Test]
        public void FailRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();
            
            user.Name = "";
            registryPage.Navigate().Guest().FillUser(user).Submit();

            user.Name = WordCreator.GetRandomWord(10);
            user.Organization = "";
            registryPage.Navigate().Guest().FillUser(user).Submit();
            
            user.Organization = WordCreator.GetRandomWord(10);
            user.Email = "test@ui";
            registryPage.Navigate().Guest().FillUser(user).Submit();
            
            user.Email = WordCreator.GetRandomEmail(6);
            user.Password = "";
            registryPage.Navigate().Guest().FillUser(user).Submit();
        }
        
        [Test]
        public void SuccesfulTestSignIn()
        {
            Login loginPage = new Login(_chromeDriver);
            User user = User.ValidUser();

            loginPage.Navigate().FillUser(user).Submit();
        }
        
        [Test]
        public void FailTestSignIn()
        {
            Login loginPage = new Login(_chromeDriver);
            User  user = User.GetRandomUserForRegistration();

            loginPage.Navigate().FillUser(user).Submit();
        }

        [Test]
        public void SuccessCreateProject()
        {
            Login();
            
            ProjectPages projectPages = new ProjectPages(_chromeDriver);
            Project project = Project.GetRandomProject();
            projectPages.Navigate().CreateProject().FillProject(project).Submit();
        } 
        
        public void Login()
        {
            Login loginPage = new Login(_chromeDriver);
            User user = User.ValidUser();
            
            loginPage.Navigate().FillUser(user).Submit();
        }
        
    }
}
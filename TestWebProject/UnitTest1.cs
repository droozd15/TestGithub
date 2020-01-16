using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tests.Exception;
using Tests.Helpers;
using Tests.Models;
using Tests.Pages;

namespace Tests
{
    public class Tests
    {
        private IWebDriver _chromeDriver;
        
        [OneTimeSetUp]
        public void Setup()
        {
            _chromeDriver = new ChromeDriver("C:/Users/Anna Zanovskaya/RiderProjects/TestWebProject/TestWebProject/bin/Debug/netcoreapp2.1");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _chromeDriver.Quit();
        }        
       
        [Test]
        public void SuccesfulRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();

            Assert.NotNull(registryPage.Navigate().Guest().FillUser(user).Submit());
            
            registryPage.Exit();
        }   
     
        
        [Test]
        public void FailRegistry()
        {
            RegistryPages registryPage = new RegistryPages(_chromeDriver);
            User user = User.GetRandomUserForRegistration();
            
            user.Name = "";
            try
            {
                registryPage.Navigate().Guest().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Данные для входа некорректны!",e.Message);
            }
            

            user.Name = WordCreator.GetRandomWord(10);
            user.Organization = "";
            try
            {
                registryPage.Navigate().Guest().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Данные для входа некорректны!",e.Message);
            }
            
            user.Organization = WordCreator.GetRandomWord(10);
            user.Email = "t";
            try
            {
                registryPage.Navigate().Guest().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Данные для входа некорректны!",e.Message);
            }
            
            user.Email = WordCreator.GetRandomEmail(6);
            user.Password = "";
            try
            {
                registryPage.Navigate().Guest().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Данные для входа некорректны!",e.Message);
            }
        }
        
        [Test]
        public void SuccesfulTestSignIn()
        {
            Login loginPage = new Login(_chromeDriver);
            User user = User.ValidUser();

            Assert.NotNull(loginPage.Navigate().FillUser(user).Submit());
            loginPage.ToNotifications().Exit();
        }
        
        [Test]
        public void FailTestSignIn()
        {
            Login loginPage = new Login(_chromeDriver);
            User  user = User.GetRandomUserForRegistration();

            try
            {
                loginPage.Navigate().FillUser(user).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Данные для входа некорректны!",e.Message);
            }
        }


        [Test]
        public void SuccessfulCreateProject()
        {
            Login loginPage = Login();
            
            ProjectPages projectPages = new ProjectPages(_chromeDriver);
            Project project = Project.GetRandomProject();
            
            Assert.NotNull(projectPages.Navigate().CreateProject().FillProject(project).Submit());
            loginPage.ToNotifications().Exit();
        }
        [Test]
        public void FailCreateProject()
        {
            Login loginPage = Login();
            
            ProjectPages projectPages = new ProjectPages(_chromeDriver);
            Project project = Project.GetEmptyProject();
            
            try
            {
                projectPages.Navigate().CreateProject().FillProject(project).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Название не может быть пустым!",e.Message);
            }

            loginPage.ToNotifications().Exit();
        }
        [Test]
        public void SuccessCreateTask()
        {
            Login loginPage = Login();
            
            ProjectPages projectPages = new ProjectPages(_chromeDriver);
            Project project = Project.GetRandomProject();
            
            TaskPages taskPage = projectPages.Navigate().CreateProject().FillProject(project).Submit().CreateTask();
            
            Task task = Task.GetRandomTask();
            taskPage.FillTask(task).Submit();
            loginPage.ToNotifications().Exit();
        } 
        [Test]
        public void FailCreateTask()
        {
            Login loginPage = Login();
            
            ProjectPages projectPages = new ProjectPages(_chromeDriver);
            Project project = Project.GetRandomProject();
            
            TaskPages taskPage = projectPages.Navigate().CreateProject().FillProject(project).Submit().CreateTask();
            
            Task task = Task.GetEmptyTask();
            try
            {
                taskPage.FillTask(task).Submit();
            }
            catch (MessageException e)
            {
                Assert.AreEqual("Название не может быть пустым!",e.Message);
            }
            loginPage.ToNotifications().Exit();
        } 
        public Login Login()
        {
            Login loginPage = new Login(_chromeDriver);
            User user = User.ValidUser();
            
            loginPage.Navigate().FillUser(user).Submit();
            return loginPage;
        }
        
    }
}

using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.LoginForm
{
    public class LoggedInUserPermissions : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public LoggedInUserPermissions()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("savetovaliste.jasmina@gmail.com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("12345678");

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitForHomePage = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitForHomePage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/"));

        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void UserCanSeeMyGallerySection()
        {

          
        }

        [Fact]
        public void UserCanSeeCreateGallerySection()
        {


        }


        [Fact]
        public void UserCanSeeLogoutButton()
        {


        }
    }
}
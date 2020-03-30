using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.LoginForm
{
    public class LoginSubmit : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public LoginSubmit()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));

        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void ValidDataIsSubmitted()
        {

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("savetovaliste.jasmina@gmail.com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("12345678");

            Driver.FindElement(By.ClassName("btn")).Click();

            string currentUrl = Driver.Url;

            Assert.Equal("https://gallery-app.vivifyideas.com/", currentUrl);
        }

        [Fact]
        public void InvalidPasswordIsNotSubmitted()
        {

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("savetovaliste.jasmina@gmail.com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("********");

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitErrorMessage = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitErrorMessage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("alert")));

            string errorMessage = Driver.FindElement(By.ClassName("alert")).Text;
            string currentUrl = Driver.Url;

            Assert.Contains("Bad Credentials", errorMessage);
            Assert.Equal("https://gallery-app.vivifyideas.com/login", currentUrl);
        }

        [Fact]
        public void InvalidEmailIsNotSubmitted()
        {

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("fakeemail@com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("12345678");

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitErrorMessage = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitErrorMessage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("alert")));

            string errorMessage = Driver.FindElement(By.ClassName("alert")).Text;
            string currentUrl = Driver.Url;

            Assert.Contains("Bad Credentials", errorMessage);
            Assert.Equal("https://gallery-app.vivifyideas.com/login", currentUrl);
        }

    }
}

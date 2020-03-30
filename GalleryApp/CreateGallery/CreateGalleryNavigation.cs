using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.CreateGallery
{
    public class CreateGalleryNavigation : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void CreateGalleryShouldOpen()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/login"));

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("savetovaliste.jasmina@gmail.com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("12345678");

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitLoginToFinish = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitLoginToFinish.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com"));

            Driver.FindElements(By.ClassName("nav"))[2].Click();

            var waitForTheForm = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitForTheForm.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/create"));

            string currentUrl = Driver.Url;

            Assert.Equal("https://gallery-app.vivifyideas.com/create", currentUrl);

        }
    }
}
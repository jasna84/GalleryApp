using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.RegisterForm
{
    public class RegisterNavigation : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void RegistrationPageShouldOpen()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/register");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/register"));

            string currentUrl = Driver.Url;

            Assert.Equal("https://gallery-app.vivifyideas.com/register", currentUrl);
        }
    }

}

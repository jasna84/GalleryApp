using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.LoginForm
{
    public class LoginNavigation : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void LoginPageShouldOpen()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/login"));

            string currentUrl = Driver.Url;

            Assert.Equal("https://gallery-app.vivifyideas.com/login", currentUrl);
        }

    }  
}

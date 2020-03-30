using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.LoginForm
{
    public class LoginFields : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public LoginFields()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://gallery-app.vivifyideas.com/login"));

        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void LoginFieldForEmailIsVisible()
        {

            try
            {
                Driver.FindElement(By.Id("email"));
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("email")));
                Assert.True(true, "message");
            }
            catch(Exception ex)
            {
                Assert.True(false, "message");
            }
        

        }

        [Fact]
        public void LoginFieldForPasswordIsVisible()
        {

            try
            {
                Driver.FindElement(By.Id("password"));
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("password")));
                Assert.True(true, "message");
            }
            catch (Exception ex)
            {
                Assert.True(false, "message");
            }

        }
    }
}

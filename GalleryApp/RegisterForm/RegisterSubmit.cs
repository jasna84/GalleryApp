using GalleryAppResources;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GalleryApp.LoginForm
{
    public class RegisterSubmit : IDisposable
    {
        public IWebDriver Driver { get; set; }

        public RegisterSubmit()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);

            Driver.Navigate().GoToUrl("https://gallery-app.vivifyideas.com/login");

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("first-name")));

        }


        public void Dispose()
        {
            Driver.Close();
            Driver.Quit();
        }

        [Fact]
        public void ValidDataForRegistrationIsSubmitted()
        {
              
            Random rnd = new Random();

            string rndFirstName = Convert.ToString(rnd.Next(11111111, 99999999));
            string rndLastName = Convert.ToString(rnd.Next(11111111, 99999999));
            string rndEmail = Convert.ToString(rnd.Next(0, 999999));
            string rndPass = Convert.ToString(rnd.Next(11111111, 99999999));

            Driver.FindElement(By.Id("first-name")).Click();
            Driver.FindElement(By.Id("first-name")).SendKeys(rndFirstName);

            Driver.FindElement(By.Id("last-name")).Click();
            Driver.FindElement(By.Id("last-name")).SendKeys(rndLastName);

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("jasna" + rndEmail + "test@com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys(rndPass);

            Driver.FindElement(By.Id("password-confirmation")).Click();
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(rndPass);

            Driver.FindElement(By.ClassName("form-check-input")).Click();

            Driver.FindElement(By.ClassName("btn")).Click();
      
            string currentUrl = Driver.Url;

            Assert.Equal("https://gallery-app.vivifyideas.com/", currentUrl);
        }

        [Fact]
        public void FormWithoutAcceptedTermsIsNotSubmitted()
        {

            Random rnd = new Random();

            string rndFirstName = Convert.ToString(rnd.Next(11111111, 99999999));
            string rndLastName = Convert.ToString(rnd.Next(11111111, 99999999));
            string rndEmail = Convert.ToString(rnd.Next(0, 999999));
            string rndPass = Convert.ToString(rnd.Next(11111111, 99999999));

            Driver.FindElement(By.Id("first-name")).Click();
            Driver.FindElement(By.Id("first-name")).SendKeys(rndFirstName);

            Driver.FindElement(By.Id("last-name")).Click();
            Driver.FindElement(By.Id("last-name")).SendKeys(rndLastName);

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("jasna" + rndEmail + "test@com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys(rndPass);

            Driver.FindElement(By.Id("password-confirmation")).Click();
            Driver.FindElement(By.Id("password-confirmation")).SendKeys(rndPass);

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitErrorMessage = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitErrorMessage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("alert")));

            string errorMessage = Driver.FindElement(By.ClassName("alert")).Text;
            string currentUrl = Driver.Url;
           
            Assert.Contains("The terms and conditions must be accepted.", errorMessage);
            Assert.Equal("https://gallery-app.vivifyideas.com/register", currentUrl);
        }

        [Fact]
        public void UserWithDuplicateEmailIsNotRegistered()
        {

            Random rnd = new Random();

            string rndFirstName = Convert.ToString(rnd.Next(11111111, 99999999));
            string rndLastName = Convert.ToString(rnd.Next(11111111, 99999999));


            Driver.FindElement(By.Id("first-name")).Click();
            Driver.FindElement(By.Id("first-name")).SendKeys(rndFirstName);

            Driver.FindElement(By.Id("last-name")).Click();
            Driver.FindElement(By.Id("last-name")).SendKeys(rndLastName);

            Driver.FindElement(By.Id("email")).Click();
            Driver.FindElement(By.Id("email")).SendKeys("savetovaliste.jasmina@gmail.com");

            Driver.FindElement(By.Id("password")).Click();
            Driver.FindElement(By.Id("password")).SendKeys("12345678");

            Driver.FindElement(By.Id("password-confirmation")).Click();
            Driver.FindElement(By.Id("password-confirmation")).SendKeys("12345678");

            Driver.FindElement(By.ClassName("form-check-input")).Click();

            Driver.FindElement(By.ClassName("btn")).Click();

            var waitErrorMessage = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            waitErrorMessage.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.ClassName("alert")));

            string errorMessage = Driver.FindElement(By.ClassName("alert")).Text;
            string currentUrl = Driver.Url;

            Assert.Contains("The email has already been taken.", errorMessage);
            Assert.Equal("https://gallery-app.vivifyideas.com/register", currentUrl);
        }

    }
}

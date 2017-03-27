using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBgTestsBase;
using CarsBgPages.LoginForm;

namespace CarsBgTests.LoginFormTests
{
    [TestClass]
    public class CarsBgLoginFormTests : CarsBgBase
    {
        public CarsBgLoginFormTests()
        {
            LoginForm = new CarsBgLoginForm();
        }


        public CarsBgLoginForm LoginForm { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, LoginForm);
            Driver.Navigate().GoToUrl(HomePage.urlToCarsBgHomePage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestMethod]
        public void LoginFormPrivateSellerCredentialError()
        {
            LoginForm.CarsBgLoginButtonElement.Click();
            LoginForm.CarsBgLoginFormPrivateSeller.Click();
            LoginForm.LoginToAccountButton.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.ClassName("error")));

            string expectedErrorMessage = "Грешен телефон или\r\nпарола";
            var actualsErrorMessage = LoginForm.LoginErrorElement.Text;

            Assert.AreEqual(expectedErrorMessage, actualsErrorMessage);
        }

        [TestMethod]
        public void LoginFormCompanyCredentialError()
        {
            LoginForm.CarsBgLoginButtonElement.Click();
            LoginForm.CarsBgLoginFormCompany.Click();
            LoginForm.LoginToAccountButton.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.ClassName("error")));

            string expectedErrorMessage = "Грешен потребител или\r\nпарола";
            var actualErrorMessage = LoginForm.LoginErrorElement.Text;

            Assert.AreEqual(expectedErrorMessage, actualErrorMessage);
        }
    }
}

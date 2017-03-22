using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBg_BaseClass;
using CarsBg_Login_Form;

namespace CarsBg_Login_Form_Tests
{
    [TestClass]
    public class CarsBgLoginFormTests : CarsBgBaseClass
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
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [Ignore]
        [TestMethod]
        public void LoginFormPrivateSellerCredentialError()
        {
            LoginForm.CarsBgLoginButtonElement.Click();

            LoginForm.CarsBgLoginFormPrivateSeller.Click();

            LoginForm.LoginToAccountButton.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.ClassName("error")));

            string expectedMessage = "Грешен телефон или\r\nпарола";
            var actualsErrorMessage = LoginForm.LoginErrorElement.Text;

            Assert.AreEqual(expectedMessage, actualsErrorMessage);
        }

        [Ignore]
        [TestMethod]
        public void LoginFormCompanyCredentialError()
        {
            LoginForm.CarsBgLoginButtonElement.Click();

            LoginForm.CarsBgLoginFormCompany.Click();

            LoginForm.LoginToAccountButton.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.ClassName("error")));

            string expectedMessage = "Грешен потребител или\r\nпарола";
            var actualMessage = LoginForm.LoginErrorElement.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}

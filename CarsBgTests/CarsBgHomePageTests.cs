using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBgTestsBase;
using CarsBgPages.HomePage;

namespace CarsBgTests.HomePageTests
{
    [TestClass]
    public class CarsBgHomePageTests : CarsBgBase
    {

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, HomePage);
            Driver.Navigate().GoToUrl(HomePage.urlToCarsBgHomePage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestMethod]
        public void GoToCarsBgHomePage()
        {
            string expectedPageTitle = "cars.bg - Търсите Автомобили? Нови, buyback, лизингови и употребявани коли";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

    }
}

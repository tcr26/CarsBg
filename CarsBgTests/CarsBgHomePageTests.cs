using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBg_HomePage;
using CarsBg_BaseClass;

namespace CarsBg_HomePage_Tests
{
    [TestClass]
    public class CarsBgHomePageTests : CarsBgBaseClass
    {
        public CarsBgHomePageTests()
        {
        }


        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, HomePage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [Ignore]
        [TestMethod]
        public void GoToCarsBgHomePage()
        {
            string expectedPageTitle = "cars.bg - Търсите Автомобили? Нови, buyback, лизингови и употребявани коли";
            var actualPageTitle = Driver.Title;

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }

    }
}

﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBgPages_HomePage;

namespace CarsBg_HomePage_Tests
{
    [TestClass]
    public class CarsBgHomePageTests
    {
        public CarsBgHomePageTests()
        {
            CarsBgHomePageClass = new CarsBgHomePage();
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.Navigate().GoToUrl(CarsBgHomePageClass.urlToCarsBgHomePage);
        }

        public CarsBgHomePage CarsBgHomePageClass { get; set; }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Waiter { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, CarsBgHomePageClass);
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

        //[Ignore]
        [TestMethod]
        public void ClickOnSearchButton()
        {
            string expectedPageTitle = "cars.bg - Търсите Автомобили? Нови, buyback, лизингови и употребявани коли";
            var actualPageTitle = Driver.Title;

            CarsBgHomePageClass.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.TitleIs("asd"));

            Assert.AreEqual(expectedPageTitle, actualPageTitle);
        }
    }
}

using System;
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
            HomePage = new CarsBgHomePage();
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.Navigate().GoToUrl(HomePage.urlToCarsBgHomePage);
        }

        public CarsBgHomePage HomePage { get; set; }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Waiter { get; set; }

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

        [Ignore]
        [TestMethod]
        public void SearchForSnowmobile()
        {
            HomePage.FilterByAutomobilesTypes.Click();

            HomePage.Select(HomePage.FilterByAutomobilesTypes, "Мотори");

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            HomePage.FilterByCoupes.Click();

            HomePage.Select(HomePage.FilterByCoupes, "Моторна шейна");

            HomePage.FilterByCarsFromPrice.SendKeys("1000");
            HomePage.FilterByCarsToPrice.SendKeys("17000");

            HomePage.FilterByUsedCars.Click();

            HomePage.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            var expectedChooseType = "Търсене: Секция: Мотори; Цена: от 1000 до 17000 ЛЕВА; Тип: Моторна шейна; Обяви за: Нови; Обяви от: Автокъщи/Търговци и частни лица, Официални вносители Промени търсенето";
            var actualChooseType = HomePage.SearchTermsElement.Text;

            Assert.AreEqual(expectedChooseType, actualChooseType);
        }

        //[Ignore]
        [TestMethod]
        public void NoResultsFoundForSnowmobile()
        {
            HomePage.FilterByAutomobilesTypes.Click();

            HomePage.Select(HomePage.FilterByAutomobilesTypes, "Мотори");

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            HomePage.FilterByCoupes.Click();

            HomePage.Select(HomePage.FilterByCoupes, "Моторна шейна");

            HomePage.FilterByCarsFromPrice.SendKeys("1000");
            HomePage.FilterByCarsToPrice.SendKeys("17000");

            HomePage.FilterByUsedCars.Click();

            HomePage.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            if (HomePage.NumbersOfSearchResultsElement.Text == "1-0 от 0 оферти")
            {
                var expectedChooseType = "Няма намерени резултати";
                var actualChooseType = HomePage.NoResultsFoundElement.Text;

                Assert.AreEqual(expectedChooseType, actualChooseType);
            }
        }
    }
}

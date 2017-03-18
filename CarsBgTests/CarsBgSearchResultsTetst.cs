using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBg_HomePage;
using CarsBgSearch_Results;
using System.Collections.Generic;
using System.Linq;

namespace CarsBg_Search_Results_Tests
{
    [TestClass]
    public class CarsBgSearchResultsTests
    {
        public CarsBgSearchResultsTests()
        {
            HomePage = new CarsBgHomePage();
            SearchResults = new CarsBgSearchResults();
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            Driver.Navigate().GoToUrl(SearchResults.urlToCarsBgHomePage);
        }

        public CarsBgHomePage HomePage { get; set; }

        public CarsBgSearchResults SearchResults { get; set; }

        public IWebDriver Driver { get; set; }

        public WebDriverWait Waiter { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, HomePage);
            PageFactory.InitElements(Driver, SearchResults);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        //[Ignore]
        [TestMethod]
        public void SearchForSnowmobile()
        {
            SearchResults.FilterByAutomobilesTypes.Click();

            SearchResults.SelectOptionElement(SearchResults.FilterByAutomobilesTypes, "Мотори");

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            SearchResults.FilterByCoupes.Click();

            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Моторна шейна");

            SearchResults.FilterByCarsFromPrice.SendKeys("1000");
            SearchResults.FilterByCarsToPrice.SendKeys("17000");

            SearchResults.UsedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            var expectedChooseType = "Търсене: Секция: Мотори; Цена: от 1000 до 17000 ЛЕВА; Тип: Моторна шейна; Обяви за: Нови; Обяви от: Автокъщи/Търговци и частни лица, Официални вносители Промени търсенето";
            var actualChooseType = SearchResults.SearchTermsElement.Text;

            Assert.AreEqual(expectedChooseType, actualChooseType);
        }

        //[Ignore]
        [TestMethod]
        public void SearchForSedanFourDoorsGasoline()
        {
            SearchResults.FilterByCoupes.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Седан");

            SearchResults.FilterByDoorsCount.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByDoorsCount, "4/5");

            SearchResults.FilterByFuelType.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByFuelType, "Газ/Бензин");

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("carsForm")));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedFuelTypeMessage = "Газ/Бензин";
            var actualFuelyTypeMessage = SearchResults.FuelType.Text;
            Assert.AreEqual(expectedFuelTypeMessage, actualFuelyTypeMessage);

            string expectedDoorsMessage = "4/5 врати";
            var actualDoorsMessage = SearchResults.NumberOfDoors.Text;
            Assert.AreEqual(expectedDoorsMessage, actualDoorsMessage);
        }

        //[Ignore]
        [TestMethod]
        public void SearchForSparePartsCars()
        {
            SearchResults.NewCars.Click();
            SearchResults.UsedCars.Click();
            SearchResults.SparePartsCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("carsForm")));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedSparePartsMessage = "за части";
            var actualSparePartsMessage = SearchResults.DamagedAndSparePartsMessageElement.Text;

            Assert.AreEqual(expectedSparePartsMessage, actualSparePartsMessage);
        }

        //[Ignore]
        [TestMethod]
        public void SearchForDamagedCars()
        {
            SearchResults.NewCars.Click();
            SearchResults.UsedCars.Click();
            SearchResults.DamagedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("carsForm")));

            SearchResults.FirstSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedSparePartsMessage = "повредени/ударени";
            var actualSparePartsMessage = SearchResults.DamagedAndSparePartsMessageElement.Text;

            Assert.AreEqual(expectedSparePartsMessage, actualSparePartsMessage);
        }

        //[Ignore]
        [TestMethod]
        public void SearchForSedanThreeDoorsDiesel()
        {
            SearchResults.FilterByCoupes.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Седан");

            SearchResults.FilterByDoorsCount.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByDoorsCount, "2/3");

            SearchResults.FilterByFuelType.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByFuelType, "Дизел");

            SearchResults.FilterByCarsFromPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsFromPrice, "от 1000");

            SearchResults.FilterByCarsToPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsToPrice, "до 2000");

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("carsForm")));

            SearchResults.FirstSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedFuelTypeMessage = "Дизел";
            var actualFuelyTypeMessage = SearchResults.FuelType.Text;
            Assert.AreEqual(expectedFuelTypeMessage, actualFuelyTypeMessage);

            string expectedDoorsMessage = "2/3 врати";
            var actualDoorsMessage = SearchResults.NumberOfDoors.Text;
            Assert.AreEqual(expectedDoorsMessage, actualDoorsMessage);
        }

        [Ignore]
        [TestMethod]
        public void PriceCheck()
        {

            SearchResults.FilterByCoupes.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Седан");

            SearchResults.FilterByDoorsCount.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByDoorsCount, "2/3");

            SearchResults.FilterByFuelType.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByFuelType, "Дизел");

            SearchResults.FilterByCarsFromPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsFromPrice, "от 1000");

            SearchResults.FilterByCarsToPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsToPrice, "до 2000");

            SearchResults.SortTheResultsBy.Click();
            SearchResults.SelectOptionElement(SearchResults.SortTheResultsBy, "Цена - най-ниска");

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("carsForm")));

            IList<IWebElement> priceElement = Driver.FindElements(By.ClassName("ver20black"));

            foreach (var items in priceElement)
            {
            }
        }

        //[Ignore]
        [TestMethod]
        public void NoResultsFoundForSnowmobile()
        {
            SearchResults.SelectOptionElement(SearchResults.FilterByAutomobilesTypes, "Мотори");

            //SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            SearchResults.FilterByCoupes.Click();

            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Моторна шейна");

            //SearchResults.FilterByCarsFromPrice.SendKeys("1");
            SearchResults.FilterByCarsToPrice.SendKeys("1");

            SearchResults.UsedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            if (SearchResults.NumbersOfSearchResultsElements.Text == "1-0 от 0 оферти")
            {
                var expectedChooseType = "Няма намерени резултати";
                var actualChooseType = SearchResults.NoResultsFoundElement.Text;

                Assert.AreEqual(expectedChooseType, actualChooseType);
            }
        }
    }
}

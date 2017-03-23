using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Firefox;
using CarsBg_BaseClass;
using CarsBgSearch_Results;


namespace CarsBg_Search_Results_Tests
{
    [TestClass]
    public class CarsBgSearchResultsTests : CarsBgBaseClass
    {
        public CarsBgSearchResultsTests()
        {
            SearchResults = new CarsBgSearchResults();
        }

        public CarsBgSearchResults SearchResults { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            PageFactory.InitElements(Driver, SearchResults);
            Driver.Navigate().GoToUrl(HomePage.urlToCarsBgHomePage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [TestMethod]
        public void SearchForSnowmobile()
        {
            SearchResults.FilterByAutomobilesTypes.Click();

            SearchResults.SelectDropDownItem(SearchResults.FilterByAutomobilesTypes, "Мотори");

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            SearchResults.FilterByCoupes.Click();

            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Моторна шейна");

            SearchResults.FilterByCarsFromPrice.SendKeys("1000");
            SearchResults.FilterByCarsToPrice.SendKeys("17000");

            SearchResults.UsedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            var expectedChooseType = "Търсене: Секция: Мотори; Цена: от 1000 до 17000 ЛЕВА; Тип: Моторна шейна; Обяви за: Нови; Обяви от: Автокъщи/Търговци и частни лица, Официални вносители Промени търсенето";
            var actualChooseType = SearchResults.SearchTermsElement.Text;

            Assert.AreEqual(expectedChooseType, actualChooseType);
        }

        [TestMethod]
        public void SearchForSedanFourDoorsGasoline()
        {
            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Седан");
            SearchResults.SelectDropDownItem(SearchResults.FilterByDoorsCount, "4/5");
            SearchResults.SelectDropDownItem(SearchResults.FilterByFuelType, "Газ/Бензин");
            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedFuelTypeMessage = "Газ/Бензин";
            var actualFuelyTypeMessage = SearchResults.FuelType.Text;
            Assert.AreEqual(expectedFuelTypeMessage, actualFuelyTypeMessage);

            string expectedDoorsMessage = "4/5 врати";
            var actualDoorsMessage = SearchResults.NumberOfDoors.Text;
            Assert.AreEqual(expectedDoorsMessage, actualDoorsMessage);
        }

        [TestMethod]
        public void SearchForSparePartsCars()
        {
            SearchResults.NewCars.Click();
            SearchResults.UsedCars.Click();
            SearchResults.SparePartsCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedSparePartsMessage = "за части";
            var actualSparePartsMessage = SearchResults.DamagedAndSparePartsMessageElement.Text;

            Assert.AreEqual(expectedSparePartsMessage, actualSparePartsMessage);
        }

        [TestMethod]
        public void SearchForDamagedCars()
        {
            SearchResults.NewCars.Click();
            SearchResults.UsedCars.Click();
            SearchResults.DamagedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedSparePartsMessage = "повредени/ударени";
            var actualSparePartsMessage = SearchResults.DamagedAndSparePartsMessageElement.Text;

            Assert.AreEqual(expectedSparePartsMessage, actualSparePartsMessage);
        }

        [TestMethod]
        public void SearchForSedanThreeDoorsDiesel()
        {
            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Седан");
            SearchResults.SelectDropDownItem(SearchResults.FilterByDoorsCount, "2/3");
            SearchResults.SelectDropDownItem(SearchResults.FilterByFuelType, "Дизел");
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsFromPrice, "от 1000");
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsToPrice, "до 2000");
            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            SearchResults.SecondSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedFuelTypeMessage = "Дизел";
            var actualFuelyTypeMessage = SearchResults.FuelType.Text;
            Assert.AreEqual(expectedFuelTypeMessage, actualFuelyTypeMessage);

            string expectedDoorsMessage = "2/3 врати";
            var actualDoorsMessage = SearchResults.NumberOfDoors.Text;
            Assert.AreEqual(expectedDoorsMessage, actualDoorsMessage);
        }

        [TestMethod]
        public void PriceCheck()
        {
            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Седан");
            SearchResults.SelectDropDownItem(SearchResults.FilterByDoorsCount, "2/3");
            SearchResults.SelectDropDownItem(SearchResults.FilterByFuelType, "Дизел");
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsFromPrice, "от 1000");

            // TODO: stale exception fix to be added            
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsToPrice, "до 2000");

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            IList<IWebElement> priceElements = Driver.FindElements(By.ClassName("ver20black"));
            AssertCollectionNotNullOrEmpty(priceElements, "Price collection is empty");

            foreach (var item in priceElements)
            {
                var priceTextElement = item.Text;
                var actualPrice = double.Parse(priceTextElement, CultureInfo.InvariantCulture);

                Assert.IsTrue(actualPrice >= 1000 && actualPrice <= 2000, "Prices are not between 1000 and 2000");
            }
        }

        [TestMethod]
        public void YearCheck()
        {
            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Седан");
            SearchResults.SelectDropDownItem(SearchResults.FilterByDoorsCount, "2/3");
            SearchResults.SelectDropDownItem(SearchResults.FilterByYearOfProduction, "от 2011");
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsFromPrice, "от 14000");
            SearchResults.SelectDropDownItem(SearchResults.FilterByCarsToPrice, "до 25000");
            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            IList<IWebElement> yearProductionElements = Driver.FindElements(By.ClassName("year"));

            AssertCollectionNotNullOrEmpty(yearProductionElements, "Year of production is empty");

            foreach (var item in yearProductionElements)
            {
                var yearProduction = item.Text;

                var actualYear = int.Parse(yearProduction, CultureInfo.InvariantCulture);

                Assert.IsTrue(actualYear >= 2011, "Year of production is incorrect");
            }
        }

        [TestMethod]
        public void NoResultsFoundForSnowmobile()
        {
            SearchResults.SelectDropDownItem(SearchResults.FilterByAutomobilesTypes, "Мотори");

            Waiter.Until(ExpectedConditions.UrlToBe("http://www.cars.bg/?go=home&p=motori"));

            SearchResults.FilterByCoupes.Click();

            SearchResults.SelectDropDownItem(SearchResults.FilterByCoupes, "Моторна шейна");

            SearchResults.FilterByCarsToPrice.SendKeys("1");

            SearchResults.UsedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id("searchstrings")));

            string expectedPagesMessage = "1-0 от 0 оферти";
            string actualPagesMessage = SearchResults.NumbersOfSearchResultsElements.Text;
            Assert.AreEqual(expectedPagesMessage, actualPagesMessage);

            var expectedNotFoundMessage = "Няма намерени резултати";
            var actualNotFoundMessage = SearchResults.NoResultsFoundElement.Text;
            Assert.AreEqual(expectedNotFoundMessage, actualNotFoundMessage);
        }

        private void AssertCollectionNotNullOrEmpty(IList<IWebElement> collectionToAssert, string message)
        {
            if (collectionToAssert == null || collectionToAssert.Count == 0)
            {
                Assert.Fail(message);
            }
        }
    }
}

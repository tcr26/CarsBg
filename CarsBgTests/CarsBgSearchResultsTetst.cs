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
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }

        [Ignore]
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

        [Ignore]
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

        [Ignore]
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

        [Ignore]
        [TestMethod]
        public void SearchForDamagedCars()
        {
            SearchResults.NewCars.Click();
            SearchResults.UsedCars.Click();
            SearchResults.DamagedCars.Click();

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            SearchResults.FirstSearchResultElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td b")));

            string expectedSparePartsMessage = "повредени/ударени";
            var actualSparePartsMessage = SearchResults.DamagedAndSparePartsMessageElement.Text;

            Assert.AreEqual(expectedSparePartsMessage, actualSparePartsMessage);
        }

        [Ignore]
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

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

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

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            IList<IWebElement> priceElement = Driver.FindElements(By.ClassName("ver20black"));

            foreach (var item in priceElement)
            {
                var priceTextElement = item.Text;

                var priceTextToNumber = double.Parse(priceTextElement, CultureInfo.InvariantCulture);

                for (int i = 0; i < priceTextElement.Length; i++)
                {
                    if (priceTextToNumber < 1000 || priceTextToNumber > 2000)
                    {
                        Assert.Fail("Prices out of range!");
                    }
                }
            }
        }

        [Ignore]
        [TestMethod]
        public void YearCheck()
        {
            SearchResults.FilterByCoupes.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCoupes, "Седан");

            SearchResults.FilterByDoorsCount.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByDoorsCount, "2/3");

            SearchResults.FilterByYearOfProduction.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByYearOfProduction, "от 2011");

            SearchResults.FilterByCarsFromPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsFromPrice, "от 14000");

            SearchResults.FilterByCarsToPrice.Click();
            SearchResults.SelectOptionElement(SearchResults.FilterByCarsToPrice, "до 25000");

            SearchResults.SearchButtonElement.Click();

            Waiter.Until(ExpectedConditions.ElementIsVisible(By.Id(SearchResults.vehicleInformationElement)));

            IList<IWebElement> priceElement = Driver.FindElements(By.ClassName("year"));

            foreach (var item in priceElement)
            {
                var priceYearElement = item.Text;

                var priceYearToNumber = int.Parse(priceYearElement, CultureInfo.InvariantCulture);

                for (int i = 0; i < priceYearElement.Length; i++)
                {
                    if (priceYearToNumber < 2011)
                    {
                        Assert.Fail("Year if production out of range!");
                    }
                }
            }
        }

        [Ignore]
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

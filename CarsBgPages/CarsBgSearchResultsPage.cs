﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CarsBgPages.SearchResults
{
    public class CarsBgSearchResults
    {
        public string urlToCarsBgHomePage = "http://www.cars.bg";

        [FindsBy(How = How.Id, Using = "section")]
        public IWebElement FilterByAutomobilesTypes { get; set; }

        [FindsBy(How = How.Id, Using = "categoryId")]
        public IWebElement FilterByCoupes { get; set; }

        [FindsBy(How = How.Id, Using = "doorId")]
        public IWebElement FilterByDoorsCount { get; set; }

        [FindsBy(How = How.Id, Using = "RegionId")]
        public IWebElement FilterByRegions { get; set; }

        [FindsBy(How = How.Id, Using = "BrandId")]
        public IWebElement FilterByBrands { get; set; }

        [FindsBy(How = How.Id, Using = "modelId")]
        public IWebElement FilterByModels { get; set; }

        [FindsBy(How = How.Id, Using = "fuelId")]
        public IWebElement FilterByFuelType { get; set; }

        [FindsBy(How = How.Id, Using = "gearId")]
        public IWebElement FilterByGearType { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor4")]
        public IWebElement NewCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor1")]
        public IWebElement UsedCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor2")]
        public IWebElement DamagedCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor3")]
        public IWebElement SparePartsCars { get; set; }

        [FindsBy(How = How.Id, Using = "YearFrom")]
        public IWebElement FilterByYearOfProduction { get; set; }

        [FindsBy(How = How.Id, Using = "PriceFrom")]
        public IWebElement FilterByCarsFromPrice { get; set; }

        [FindsBy(How = How.Id, Using = "PriceTo")]
        public IWebElement FilterByCarsToPrice { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr/td[1]/table/tbody/tr[1]/td/div/form/div/table/tbody/tr[3]/td/table/tbody/tr/td[1]/select")]
        public IWebElement SortTheResultsBy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table tbody tr td table tbody tr td table tbody tr td div#Container form#Form div.box-rounded table tbody tr td table tbody tr td a.link12orr")]
        public IWebElement AdvancedSearchButtonElement { get; set; }

        [FindsBy(How = How.XPath, Using = "//b[contains(.,'Търсене')]")]
        public IWebElement SearchButtonElement { get; set; }

        [FindsBy(How = How.Id, Using = "searchstrings")]
        public IWebElement SearchTermsElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table.tableListResults tbody tr th div")]
        public IWebElement NumbersOfSearchResultsElements { get; set; }

        [FindsBy(How = How.ClassName, Using = "tableListResults")]
        public IWebElement SearchResultsElements { get; set; }

        [FindsBy(How = How.ClassName, Using = "ver15black")]
        public IWebElement SearchResultSellLinkElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "year")]
        public IWebElement SearchResultProductionYearElemement { get; set; }

        [FindsBy(How = How.ClassName, Using = "ver20black")]
        public IWebElement SearchResultPriceElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.odd:nth-child(2) > td:nth-child(2) > a:nth-child(1) > span:nth-child(1) > b:nth-child(1)")]
        public IWebElement FirstSearchResultElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "tr.even:nth-child(3) > td:nth-child(2) > a:nth-child(1) > span:nth-child(1) > b:nth-child(1)")]
        public IWebElement SecondSearchResultElement { get; set; }

        public string vehicleInformationElement = "carsForm";

        [FindsBy(How = How.CssSelector, Using = "html body table tbody tr td table tbody tr td table.ver13black tbody tr td table tbody tr td span")]
        public IWebElement DamagedAndSparePartsMessageElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement YearOfProductionElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(2)")]
        public IWebElement KilometersTraveled { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(2)")]
        public IWebElement FuelType { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(2)")]
        public IWebElement TransmissionType { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2)")]
        public IWebElement HorsePower { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(2) > td:nth-child(2)")]
        public IWebElement CubicCentimeters { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(2)")]
        public IWebElement NumberOfDoors { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ver13black > tbody:nth-child(1) > tr:nth-child(3) > td:nth-child(1) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(1) > td:nth-child(2) > table:nth-child(1) > tbody:nth-child(1) > tr:nth-child(4) > td:nth-child(2)")]
        public IWebElement CoupeColor { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[3]/tbody/tr[1]/td/form/table/tbody/tr/td[1]/table[4]/tbody/tr[2]/td/table/tbody/tr[2]/td")]
        public IWebElement NoResultsFoundElement { get; set; }

        public void SelectDropDownItem(IWebElement element, string option)
        {
            element.Click();
            SelectElement selectedElement = new SelectElement(element);
            selectedElement.SelectByText(option);
        }
    }
}

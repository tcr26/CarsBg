using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace CarsBgPages.HomePage
{
    public class CarsBgHomePage
    {
        public string urlToCarsBgHomePage = "http://www.cars.bg";

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td a img")]
        public IWebElement CarsBgLogoSignElement { get; set; }

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
        public IWebElement FilterByNewCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor1")]
        public IWebElement FilterByUsedCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor2")]
        public IWebElement FilterByDamagedCars { get; set; }

        [FindsBy(How = How.Id, Using = "offersFor3")]
        public IWebElement FilterBySparePartsCars { get; set; }
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

        [FindsBy(How = How.Id, Using = "filterOrderBy")]
        public IWebElement SortTheResultsBy { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[3]/tbody/tr[1]/td/table/tbody/tr[1]/td[1]/table/tbody/tr[1]/td/div/form/div/table/tbody/tr[3]/td/table/tbody/tr/td[2]/div/div/a/b")]
        public IWebElement SearchButtonElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table tbody tr td table tbody tr td table tbody tr td div#Container form#Form div.box-rounded table tbody tr td table tbody tr td a.link12orr")]
        public IWebElement AdvancedSearchButtonElement { get; set; }

        [FindsBy(How = How.Id, Using = "searchstrings")]
        public IWebElement SearchTermsElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "table.tableListResults tbody tr th div")]
        public IWebElement NumbersOfSearchResultsElement { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[3]/tbody/tr[1]/td/form/table/tbody/tr/td[1]/table[4]/tbody/tr[2]/td/table/tbody/tr[2]/td")]
        public IWebElement NoResultsFoundElement { get; set; }

        public void Select(IWebElement element, string option)
        {
            SelectElement selectedElement = new SelectElement(element);
            selectedElement.SelectByText(option);
        }
    }
}

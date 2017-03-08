using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace CarsBgPages_HomePage
{
    public class CarsBgHomePage
    {
        public string urlToCarsBgHomePage = "http://www.cars.bg";

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td a img")]
        public IWebElement CarsBgLogoSignElement { get; set; }

        [FindsBy(How = How.Id, Using = "section")]
        public IWebElement FilterByAutomobilesTypes { get; set; }

        public string SelectedCoupeType { get; set; }

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

        [FindsBy(How = How.Id, Using = "YearFrom")]
        public IWebElement FilterByYearOfProduction { get; set; }

        [FindsBy(How = How.Id, Using = "PriceFrom")]
        public IWebElement FilterByCarsFromPrice { get; set; }

        [FindsBy(How = How.Id, Using = "PriceTo")]
        public IWebElement FilterByCarsToPrice { get; set; }

        [FindsBy(How = How.Id, Using = "filterOrderBy")]
        public IWebElement SortTheResultsBy { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table tbody tr td table tbody tr td table tbody tr td div#Container form#Form div.box-rounded table tbody tr td table tbody tr td center div.bBoxT div.bBox a.buttonPressedLink b")]
        public IWebElement SearchButtonElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table tbody tr td table tbody tr td table tbody tr td div#Container form#Form div.box-rounded table tbody tr td table tbody tr td a.link12orr")]
        public IWebElement AdvancedSearchButtonElement { get; set; }

        //public void ChooseAutomobileType(string autoType)
        //{
        //    SelectElement automobileType = new SelectElement(FilterByAutomobilesTypes);

        //    FilterByAutomobilesTypes.Click();

        //    automobileType.SelectByText(autoType);
        //}

        //public void ChooseAutomobileCoupeType(string coupeType)
        //{
        //    SelectElement coupe = new SelectElement(FilterByCoupes);

        //    FilterByCoupes.Click();

        //    coupe.SelectByText(coupeType);


        //}

        //public void select(IWebElement element)
        //{
        //    SelectElement asd = new SelectElement(element);
        //    SelectedCoupeType = asd.SelectedOption.Text;
        //}
    }
}

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using CarsBgPages.HomePage;

namespace CarsBgTestsBase
{
    public abstract class CarsBgBase
    {
        public CarsBgBase()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
            Waiter = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            HomePage = new CarsBgHomePage();
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Waiter { get; set; }
        protected CarsBgHomePage HomePage { get; set; }
    }
}

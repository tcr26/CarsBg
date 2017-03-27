using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;

namespace CarsBgPages.LoginForm
{
    public class CarsBgLoginForm
    {
        public string urlToCarsBgHomePage = "http://www.cars.bg";

        [FindsBy(How = How.Id, Using = "loginlink")]
        public IWebElement CarsBgLoginButtonElement { get; set; }

        [FindsBy(How = How.Id, Using = "loginForm")]
        public IWebElement CarsBgLoginFormElement { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[3]/table/tbody/tr/td[6]/div/form/table[1]/tbody/tr[4]/td[1]/input")]
        public IWebElement CarsBgLoginFormPrivateSeller { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table#phone_table tbody tr td input")]
        public IWebElement LoginFormPrivateSellerMobilePhoneElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table#login_table tbody tr td input")]
        public IWebElement LoginFormPrivateSellerPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table tbody tr td.error")]
        public IWebElement LoginFormPrivateSellerCredentialError { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/table[2]/tbody/tr/td/table/tbody/tr/td[3]/table/tbody/tr/td[6]/div/form/table[1]/tbody/tr[4]/td[2]/input")]
        public IWebElement CarsBgLoginFormCompany { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table#username_table tbody tr td input")]
        public IWebElement LoginFormCompanyUserName { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table#login_table tbody tr td input")]
        public IWebElement LoginFormCompanyPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table tbody tr td.error")]
        public IWebElement LoginFormCompanyCredentialError { get; set; }

        [FindsBy(How = How.ClassName, Using = "error")]
        public IWebElement LoginErrorElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "html body table.site_top_head tbody tr td table tbody tr td table tbody tr td div#login_panel.login_panel form#loginForm table#login_table tbody tr td div.bBoxT div.bBox")]
        public IWebElement LoginToAccountButton { get; set; }
    }
}

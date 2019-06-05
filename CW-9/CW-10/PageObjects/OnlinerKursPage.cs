using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CW_10.PageObjects
{
    class OnlinerKursPage
    {
        private IWebDriver driver;

        public IWebElement UsdPurchasePrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][1]/tbody/tr/td[2]/p[1]/b"));

        public IWebElement UsdSellingPrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][1]/tbody/tr/td[3]/p[1]/b"));

        public IWebElement EuroPurchasePrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][2]/tbody/tr/td[2]/p[1]/b"));

        public IWebElement EuroSellingPrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][2]/tbody/tr/td[3]/p[1]/b"));

        public IWebElement RusRubPurchasePrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][3]/tbody/tr/td[2]/p[1]/b"));

        public IWebElement RusRubSellingPrice => this.driver.FindElement(By.XPath("//table[@class='b-currency-table__best'][3]/tbody/tr/td[3]/p[1]/b"));

        public OnlinerKursPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void LoadValues(List<ExchangeRate> rates)
        {
            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.UsdPurchasePrice.Enabled);
            string UsdPurchasePrice = this.UsdPurchasePrice.Text;
            rates.Add(new ExchangeRate("UsdPurchasePrice", UsdPurchasePrice));

            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.UsdSellingPrice.Enabled);
            string UsdSellingPrice = this.UsdSellingPrice.Text;
            rates.Add(new ExchangeRate("UsdSellingPrice", UsdSellingPrice));

            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.EuroPurchasePrice.Enabled);
            string EuroPurchasePrice = this.EuroPurchasePrice.Text;
            rates.Add(new ExchangeRate("EuroPurchasePrice", EuroPurchasePrice));

            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.EuroSellingPrice.Enabled);
            string EuroSellingPrice = this.EuroSellingPrice.Text;
            rates.Add(new ExchangeRate("EuroSellingPrice", EuroSellingPrice));

            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.RusRubPurchasePrice.Enabled);
            string RusRubPurchasePrice = this.RusRubPurchasePrice.Text;
            rates.Add(new ExchangeRate("100RusRubPurchasePrice", RusRubPurchasePrice));

            new WebDriverWait(this.driver, TimeSpan.FromSeconds(10)).Until(x => this.RusRubSellingPrice.Enabled);
            string RusRubSellingPrice = this.RusRubSellingPrice.Text;
            rates.Add(new ExchangeRate("100RusRubSellingPrice", RusRubSellingPrice));
        }
    }
}

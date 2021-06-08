using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV587SETOPENCART.Pages
{
    enum SortBy
    {
        Default,
        NameAZ,
        NameZA,
        PriceLowHigh,
        PriceHighLow,
        RatingHighest,
        RatingLowest,
        ModelAZ,
        ModelZA
    }

    enum PageSize
    {
        Fifteen = 15,
        TwentyFive = 25, 
        Fifty = 50,
        SeventyFive = 75,
        OneHundred = 100
    }

    class SortCategoryFilter : ClassWithDriver
    {
        public SortCategoryFilter(IWebDriver driver) : base(driver) { }

        private readonly By listButton = By.CssSelector("#list-view");
        private readonly By gridButton = By.CssSelector("#grid-view");
        private readonly By compareProductsLink = By.Id("compare-total");
        private readonly By sortByDropdown = By.Id("input-sort");
        private readonly By showDropdown = By.Id("input-limit");


        //Add about pagination

        public IWebElement SwitchToListView()
        {
            IWebElement listView = driver.FindElement(listButton);
            listView.Click();
            return listView;
        }

        public IWebElement SwitchToGridView()
        {
            IWebElement gridView = driver.FindElement(gridButton);
            gridView.Click();
            return gridView;
        }

        public void CompareProduct()
        {
            driver.FindElement(compareProductsLink).Click();
        }

        public void SortingByCriteria(SortBy criteria)
        {
            driver.FindElement(sortByDropdown).Click();

            switch (criteria)
            {
                case SortBy.Default:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(1)")).Click();
                    break;
                case SortBy.NameAZ:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(2)")).Click();
                    break;
                case SortBy.NameZA:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(3)")).Click();
                    break;
                case SortBy.PriceLowHigh:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(4)")).Click();
                    break;
                case SortBy.PriceHighLow:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(5)")).Click();
                    break;
                case SortBy.RatingHighest:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(6)")).Click();
                    break;
                case SortBy.RatingLowest:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(7)")).Click();
                    break;
                case SortBy.ModelAZ:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(8)")).Click();
                    break;
                case SortBy.ModelZA:
                    driver.FindElement(By.CssSelector("#input-sort > option:nth-child(9)")).Click();
                    break;
            }
        }

        public void ShowingElementsPerPage(PageSize number)
        {
            driver.FindElement(showDropdown).Click();

            switch (number)
            {
                case PageSize.Fifteen:
                    driver.FindElement(By.CssSelector("#input-limit > option:nth-child(1)")).Click();
                    break;
                case PageSize.TwentyFive:
                    driver.FindElement(By.CssSelector("#input-limit > option:nth-child(2)")).Click();
                    break;
                case PageSize.Fifty:
                    driver.FindElement(By.CssSelector("#input-limit > option:nth-child(3)")).Click();
                    break;
                case PageSize.SeventyFive:
                    driver.FindElement(By.CssSelector("#input-limit > option:nth-child(4)")).Click();
                    break;
                case PageSize.OneHundred:
                    driver.FindElement(By.CssSelector("#input-limit > option:nth-child(5)")).Click();
                    break;
            }
        }
    }
}

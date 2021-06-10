using OpenQA.Selenium;

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

        public IWebElement ListView { get { return driver.FindElement(By.CssSelector("#list-view")); } }
        public IWebElement GridView { get { return driver.FindElement(By.CssSelector("#grid-view")); } }
        public IWebElement CompareProductsLink { get { return driver.FindElement(By.Id("compare-total")); } }
        public IWebElement SortByDropdown { get { return driver.FindElement(By.Id("input-sort")); } }
        public IWebElement ShowDropdown { get { return driver.FindElement(By.Id("input-limit")); } }


        public IWebElement SwitchToListView()
        {
            ListView.Click();
            return ListView;
        }

        public IWebElement SwitchToGridView()
        {
            GridView.Click();
            return GridView;
        }

        public void CompareProduct()
        {
            CompareProductsLink.Click();
        }

        public void SortingByCriteria(SortBy criteria)
        {
            SortByDropdown.Click();

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
            ShowDropdown.Click();

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

using OpenQA.Selenium;
using System.Collections.Generic;

namespace LV587SETOPENCART.Pages
{
    enum DropdownCategories
    {
        Desktops,
        Monitors,
        PhonesAndPDAs
    }
    class SearchCriteriaComponent : ClassWithDriver
    {
        public SearchCriteriaComponent(IWebDriver driver) : base(driver) { }

        public IWebElement AllCategories { get { return driver.FindElement(By.CssSelector("#content > div > div:nth-child(2) > select")); } }
        public IWebElement SearchCriteriaField { get { return driver.FindElement(By.Id("input-search")); } }
        public IWebElement ProductDescriptionCheckbox { get { return driver.FindElement(By.Id("description")); } }
        public IWebElement SubcategoriesCheckbox { get { return driver.FindElement(By.Name("sub_category")); } }
        public IWebElement SearchCriteriaButton { get { return driver.FindElement(By.Id("button-search")); } }
        public IList<IWebElement> FoundProducts { get { return driver.FindElements(By.ClassName("product-thumb")); } }

        public void SearchItem(string searchText)
        {
            SearchCriteriaField.Clear();
            SearchCriteriaField.SendKeys(searchText);
        }

        public void SearchClick()
        {
            SearchCriteriaButton.Click();
        }

        public void AllCategoriesClick(DropdownCategories option)
        {
            AllCategories.Click();

            switch (option)
            {
                case DropdownCategories.Desktops:
                    driver.FindElement(By.CssSelector("#content > div:nth-child(3) > div:nth-child(2) > select > option:nth-child(2)")).Click();
                    break;
                case DropdownCategories.Monitors:
                    driver.FindElement(By.CssSelector("#content > div:nth-child(3) > div:nth-child(2) > select > option:nth-child(10)")).Click(); 
                    break;
                case DropdownCategories.PhonesAndPDAs:
                    driver.FindElement(By.CssSelector("#content > div:nth-child(3) > div:nth-child(2) > select > option:nth-child(18)")).Click(); 
                    break;
            }
        }

        public void ClickOnSearchInProdDescription()
        {
            ProductDescriptionCheckbox.Click();
        }

        public void ClickOnSearchInSubcategories()
        {
            SubcategoriesCheckbox.Click();
        }
    }
}

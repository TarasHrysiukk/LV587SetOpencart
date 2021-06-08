using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;

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

        private readonly By allCategories = By.CssSelector("#content > div > div:nth-child(2) > select");
        private readonly By searchCriteriaField = By.Id("input-search");
        private readonly By productDescriptionCheckbox = By.Id("description");
        private readonly By subcategoriesCheckbox = By.Name("sub_category");
        private readonly By searchCriteriaButton = By.Id("button-search");

        public void SearchItem(string searchText)
        {
            IWebElement search = driver.FindElement(searchCriteriaField);
            search.Clear();
            search.SendKeys(searchText);
        }

        public void SearchClick()
        {
            driver.FindElement(searchCriteriaButton).Click();
        }

        public void AllCategoriesClick(DropdownCategories option)
        {
            driver.FindElement(allCategories).Click();

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
            driver.FindElement(productDescriptionCheckbox).Click();
        }

        public void ClickOnSearchInSubcategories()
        {
            driver.FindElement(subcategoriesCheckbox).Click();
        }
    }
}

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using LV587SETOPENCART.Pages;

namespace LV587SETOPENCART.Tests
{
    class SearchTest
    {
        IWebDriver driver;
        SearchCriteriaComponent searchCriteria;
        SortCategoryFilter sortCategoryFilter;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(@"C:\chromedriver_win32");
            searchCriteria = new SearchCriteriaComponent(driver);
            sortCategoryFilter = new SortCategoryFilter(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void BeforeEachMethod()
        {
            driver.Navigate().GoToUrl("http://40.76.251.6/index.php?route=product/search");
        }


        // Test: Verify searching particular item by category 
        [Test]
        public void SearchByCategory()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            Thread.Sleep(1500); // wait
            searchCriteria.SearchClick();
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            Assert.AreEqual(2, products.Count);
            Assert.NotNull(products[0].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(products[1].FindElement(By.LinkText("MacBook Air")));
        }

        // Test: Verify searching particular item by subcategories
        [Test]
        public void SearchBySubcategory()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            searchCriteria.ClickOnSearchInSubcategories();
            Thread.Sleep(1500);//wait
            searchCriteria.SearchClick();
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            Assert.AreEqual(3, products.Count);
            Assert.NotNull(products[0].FindElement(By.LinkText("iMac")));
            Assert.NotNull(products[1].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(products[2].FindElement(By.LinkText("MacBook Air")));
        }

        // Verify search result view toggle (list/grid)
        [Test]
        public void ListView()
        {
            searchCriteria.SearchItem("ipod");
            searchCriteria.SearchClick();
            IWebElement listView = sortCategoryFilter.SwitchToListView();
            Thread.Sleep(1000); // wait

            Assert.True(listView.GetAttribute("class").Contains("active"));
        }

        // add about grid
        [Test]
        public void GridView()
        {
            searchCriteria.SearchItem("ipod");
            searchCriteria.SearchClick();
            IWebElement gridView = sortCategoryFilter.SwitchToGridView();
            Thread.Sleep(1000); // wait
            Assert.True(gridView.GetAttribute("class").Contains("active"));
        }

        [Test]
        // Search in product description (pre-condition TC "SearchByCategory")
        public void SearchInProductDescription()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            searchCriteria.ClickOnSearchInProdDescription();
            /*Thread.Sleep(1500);//wait*/
            searchCriteria.SearchClick();
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            Assert.AreEqual(4, products.Count);
            Assert.NotNull(products[0].FindElement(By.LinkText("Apple Cinema 30\"")));
            Assert.NotNull(products[1].FindElement(By.LinkText("iPhone")));
            Assert.NotNull(products[2].FindElement(By.LinkText("MacBook"))); 
            Assert.NotNull(products[3].FindElement(By.LinkText("MacBook Air")));
        }

        // Verify "Sort by" feature
        [Test]
        public void VerifySortByFeatureNameAZ()
        {
            searchCriteria.SearchItem("mac");
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchClick();
            sortCategoryFilter.SortingByCriteria(SortBy.NameAZ);
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            Assert.AreEqual(2, products.Count);
            Assert.NotNull(products[0].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(products[1].FindElement(By.LinkText("MacBook Air")));
        }

        [Test]
        public void VerifySortByFeatureNameZA()
        {

            searchCriteria.SearchItem("mac");
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchClick();
            sortCategoryFilter.SortingByCriteria(SortBy.NameZA);
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            Assert.AreEqual(2, products.Count);
            Assert.NotNull(products[0].FindElement(By.LinkText("MacBook Air")));
            Assert.NotNull(products[1].FindElement(By.LinkText("MacBook")));
        }

        [Test]
        public void VerifyShow()
        {
            searchCriteria.SearchItem("ipod");

            searchCriteria.SearchClick();

            foreach (PageSize pageSize in Enum.GetValues(typeof(PageSize)))
            {
                sortCategoryFilter.ShowingElementsPerPage(pageSize);
                IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
                Assert.AreEqual((int)pageSize, products.Count);
            }
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}

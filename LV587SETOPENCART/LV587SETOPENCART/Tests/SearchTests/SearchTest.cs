using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using LV587SETOPENCART.Pages;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("SearchTest")]
    [AllureDisplayIgnored]
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

        [Test(Description = "Verify searching particular item by category")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-168")]
        [AllureOwner("Tania Koretska")]
        public void SearchByCategory()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();

            Assert.AreEqual(2, searchCriteria.FoundProducts.Count);
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(searchCriteria.FoundProducts[1].FindElement(By.LinkText("MacBook Air")));
        }

        [Test(Description = "Verify searching particular item by subcategories")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-168")]
        [AllureOwner("Tania Koretska")]
        public void SearchBySubcategory()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            searchCriteria.ClickOnSearchInSubcategories();
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();

            Assert.AreEqual(3, searchCriteria.FoundProducts.Count);
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("iMac")));
            Assert.NotNull(searchCriteria.FoundProducts[1].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(searchCriteria.FoundProducts[2].FindElement(By.LinkText("MacBook Air")));
        }

        [Test(Description = "Verify search result view toggle (list)")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-169")]
        [AllureOwner("Tania Koretska")]
        public void ListView()
        {
            searchCriteria.SearchItem("ipod");
            searchCriteria.SearchClick();
            IWebElement listView = sortCategoryFilter.SwitchToListView();
            Thread.Sleep(1500); // ONLY FOR PRESENTATION

            Assert.True(listView.GetAttribute("class").Contains("active"));
        }

        [Test(Description = "Verify search result view toggle (grid)")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-169")]
        [AllureOwner("Tania Koretska")]
        public void GridView()
        {
            searchCriteria.SearchItem("ipod");
            searchCriteria.SearchClick();
            IWebElement gridView = sortCategoryFilter.SwitchToGridView();
            Thread.Sleep(1000); // ONLY FOR PRESENTATION

            Assert.True(gridView.GetAttribute("class").Contains("active"));
        }

        [Test(Description = "Search in product description")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-177")]
        [AllureOwner("Tania Koretska")]
        public void SearchInProductDescription()
        {
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            searchCriteria.SearchItem("mac");
            searchCriteria.ClickOnSearchInProdDescription();
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();

            Assert.AreEqual(4, searchCriteria.FoundProducts.Count);
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("Apple Cinema 30\"")));
            Assert.NotNull(searchCriteria.FoundProducts[1].FindElement(By.LinkText("iPhone")));
            Assert.NotNull(searchCriteria.FoundProducts[2].FindElement(By.LinkText("MacBook"))); 
            Assert.NotNull(searchCriteria.FoundProducts[3].FindElement(By.LinkText("MacBook Air")));
        }

        [Test(Description = "Verify \"Sort by\" feature")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-180")]
        [AllureOwner("Tania Koretska")]
        public void VerifySortByFeatureNameAZ()
        {
            searchCriteria.SearchItem("mac");
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();
            sortCategoryFilter.SortingByCriteria(SortBy.NameAZ);

            Assert.AreEqual(2, searchCriteria.FoundProducts.Count);
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("MacBook")));
            Assert.NotNull(searchCriteria.FoundProducts[1].FindElement(By.LinkText("MacBook Air")));
        }

        [Test(Description = "Verify \"Sort by\" feature")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-180")]
        [AllureOwner("Tania Koretska")]
        public void VerifySortByFeatureNameZA()
        {
            searchCriteria.SearchItem("mac");
            searchCriteria.AllCategoriesClick(DropdownCategories.Desktops);
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();
            sortCategoryFilter.SortingByCriteria(SortBy.NameZA);
            Thread.Sleep(1500); // ONLY FOR PRESENTATION

            Assert.AreEqual(2, searchCriteria.FoundProducts.Count);
            Assert.NotNull(searchCriteria.FoundProducts[0].FindElement(By.LinkText("MacBook Air")));
            Assert.NotNull(searchCriteria.FoundProducts[1].FindElement(By.LinkText("MacBook")));
        }

        [Test(Description = "Verify \"Show\" feature")]
        [AllureTag("Automation:Search")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTms("SETT-181")]
        [AllureOwner("Tania Koretska")]
        public void VerifyShow()
        {
            searchCriteria.SearchItem("ipod");
            Thread.Sleep(1500); // ONLY FOR PRESENTATION
            searchCriteria.SearchClick();

            foreach (PageSize pageSize in Enum.GetValues(typeof(PageSize)))
            {
                sortCategoryFilter.ShowingElementsPerPage(pageSize);
                Thread.Sleep(1500); // ONLY FOR PRESENTATION

                Assert.AreEqual((int)pageSize, searchCriteria.FoundProducts.Count);
            }
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}

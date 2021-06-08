using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;
using LV587SETOPENCART.Pages;

namespace LV587SETOPENCART.Tests
{
    class MainPageSearchTest
    {
        IWebDriver driver;
        HeaderComponent header;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver(@"C:\chromedriver_win32");
            header = new HeaderComponent(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void BeforeEachMethod()
        {
            driver.Navigate().GoToUrl("http://40.76.251.6/index.php?route=common/home");
        }

        // Test: Verify searching particular item from the homepage
        [Test]
        public void SearchItem()
        {
            header.SearchItem("Samsung SyncMaster 941BW");
            IList<IWebElement> products = driver.FindElements(By.ClassName("product-thumb"));
            // product count is 1
            Assert.AreEqual(1, products.Count);
            // found product is the one we were looking for
            Assert.NotNull(products[0].FindElement(By.LinkText("Samsung SyncMaster 941BW")));
        }
    }
}

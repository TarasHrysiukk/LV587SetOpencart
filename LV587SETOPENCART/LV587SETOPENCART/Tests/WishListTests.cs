using NUnit.Framework;
using System.Threading;
using LV587SETOPENCART.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace LV587SETOPENCART.Tests
{
    class WishListTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(@"http://localhost/");
        }

        [Test]
        public void AddToWishListTest_LoggIn()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            Thread.Sleep(500);
            loginPage.InputPasswordText("qwerty");

            Thread.Sleep(500);

            HeaderComponent header = new HeaderComponent(driver);
            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProd = new PageWithProducts(driver);
            pageWithProd.SelectProduct(pageWithProd.FirstProduct);
            Thread.Sleep(500);

        }

    }
}

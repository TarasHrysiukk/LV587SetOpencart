using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using LV587SETOPENCART.Tools;
using System.Threading;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class WLUnitPriceTest
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            driver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl(@"https://demo.opencart.com/");

        }

        [Test]
        public void WishListCurrenciesTest()
        {
            string currencySymbol;
            HeaderComponent header = new HeaderComponent(driver);
            PageWithProducts productPage = new PageWithProducts(driver);
            ProjectTools regex = new ProjectTools(driver);
            ProductComponents product = new ProductComponents(driver);
            CartPage cart = new CartPage(driver);
            WishListPage wishList = new WishListPage(driver);

            //Click on My Account > Login
            header.ClickOnMyAccount(MyAccountMenuActions.Login);
            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("iva@new.com", "qwerty");
            //Select category "Phones & PDAs"
            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            //Add first product to WishList from the product list
            productPage.ClickWishListButton();
            // Open WishList page
            header.ClickOnWishList();

            // Select 'Euro' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.EUR);
            currencySymbol = "€";
            //Verify that Unit Price price is displayed in euro
            bool trueCurrency = regex.PriceCurrency(wishList.GetUnitPrice(), currencySymbol);
            Assert.True(trueCurrency);

            // Select 'Pound Sterling' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.GBP);
            currencySymbol = "£";
            //Verify that Unit price is displayed in PoundsSterling
            trueCurrency = regex.PriceCurrency(wishList.GetUnitPrice(), currencySymbol);
            Assert.True(trueCurrency);

            // Select 'US Dollars' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.USD);
            currencySymbol = "$";
            //Verify that Unit price is displayed in USA Dollars 
            trueCurrency = regex.PriceCurrency(wishList.GetUnitPrice(), currencySymbol);
            Assert.True(trueCurrency);
        }
    }
}
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using LV587SETOPENCART.Tools;


namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class ProductPagePrice
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
        public void ItemPriceCurrenciesTest()
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
            //Select the product 'Iphone' from the product list
            productPage.SelectProduct(productPage.SecondProductName);
            // Select 'Euro' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.EUR);
            currencySymbol = "€";
            bool trueCurrency = regex.PriceCurrency(product.GetProductPrice(), currencySymbol);
            //Verify that product price is displayed in euro
            Assert.True(trueCurrency);

            // Select 'Pound Sterling' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.GBP);
            currencySymbol = "£";
            trueCurrency = regex.PriceCurrency(product.GetProductPrice(), currencySymbol);
            //Verify that product price is displayed in PoundsSterling
            Assert.True(trueCurrency);

            // Select 'US Dollars' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.USD);
            currencySymbol = "$";
            trueCurrency = regex.PriceCurrency(product.GetProductPrice(), currencySymbol);
            //Verify that product price is displayed in USA Dollars 
            Assert.True(trueCurrency);
        }
    }
}
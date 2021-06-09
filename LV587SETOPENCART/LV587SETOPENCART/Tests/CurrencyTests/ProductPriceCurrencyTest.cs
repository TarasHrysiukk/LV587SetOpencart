using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using LV587SETOPENCART.Tools;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.All)]
    [AllureNUnit]
    [AllureSuite("ProductPagePriceTest")]
    [AllureDisplayIgnored]

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
            string path = @"http://52.232.34.99/";
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateTo(path);
        }

        [Test]
        [AllureTag("OpenCart:Currency")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureIssue("3")]
        [AllureTms("532")]
        [AllureOwner("V.Pfayfer")]
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
            currencySymbol = "$1";
            trueCurrency = regex.PriceCurrency(product.GetProductPrice(), currencySymbol);
            //Verify that product price is displayed in USA Dollars 
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.True(trueCurrency);
            }
            catch (Exception) //Take a ScreenShot if test is failed
            {
                AfterTestScreen.SaveAsFile("C://Users//vpfaitc//Desktop//OpenCart//LV587SetOpencart//LV587SETOPENCART//LV587SETOPENCART//bin//Debug//net5.0//screens//ScreenshotItemPriceTest.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", @"C:\Users\vpfaitc\Desktop\OpenCart\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\screens\ScreenshotItemPriceTest.Png");
            }
        }
    }
}
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using LV587SETOPENCART.Tools;
using System.Threading;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;


namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("CartTPriceCyrrencyTest")]
    [AllureDisplayIgnored]

    class CartTPriceCyrrency
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
        [AllureIssue("1")]
        [AllureTms("532")]
        [AllureOwner("V.Pfayfer")]
        [AllureSubSuite("Currency")]
        public void CartCurrenciesTest()
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
            //Add first product to cart from the product list
            productPage.ClickCartButton();
            // Open cart page
            header.ClickOnShoppingCartLink();

            // Select 'Euro' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.EUR);
            currencySymbol = "€";
            Thread.Sleep(2000);
            //Verify that Total Price price is displayed in euro
            bool trueCurrency = regex.PriceCurrency(cart.GetTotalPrice(), currencySymbol);
            Assert.True(trueCurrency);

            // Select 'Pound Sterling' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.GBP);
            currencySymbol = "£";
            //Verify that Total price is displayed in PoundsSterling
            trueCurrency = regex.PriceCurrency(cart.GetTotalPrice(), currencySymbol);
            Assert.True(trueCurrency);

            // Select 'US Dollars' in dropdown 'Currency'.
            header.SelectSearch();
            header.CurrencyClickAndSelect(Currencies.USD);
            currencySymbol = "$";
            //Verify that Total price is displayed in USA Dollars 
            trueCurrency = regex.PriceCurrency(cart.GetTotalPrice(), currencySymbol);
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.True(trueCurrency);
            } catch(Exception) //Take a ScreenShot if test is failed
            {
                AfterTestScreen.SaveAsFile("C://Users//vpfaitc//Desktop//OpenCart//LV587SetOpencart//LV587SETOPENCART//LV587SETOPENCART//bin//Debug//net5.0//screens//ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", @"C:\Users\vpfaitc\Desktop\OpenCart\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\screens\ScreenshotImageFormat.Png");
            }
        }
    }
}
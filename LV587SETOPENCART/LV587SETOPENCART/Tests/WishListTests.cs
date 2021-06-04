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
            driver.Navigate().GoToUrl(@"http://localhost/");
        }

        [Test]
        public void AddToWishList()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            HeaderComponent header1 = new HeaderComponent(driver);
            header1.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageProducts = new PageWithProducts(driver);
            string expected = pageProducts.GetSelectedProductName(pageProducts.FirstProductName);

            pageProducts.GetSelectedProductName(pageProducts.FirstProductName);
            pageProducts.ClickWishListButton();

            header.ClickOnWishList();

            WishListPage wishListPage = new WishListPage(driver);
            string actual = wishListPage.GetProductName();

            Assert.AreEqual(expected, actual);

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
        }

        [Test]
        public void AddToWishList_LoggedOut()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

            string actual = pageWithProduct.GetMustLoginMessageText();

            Assert.IsTrue(actual.ToLower().Contains(" You must login or create an account to save"));
        }

        [Test]
        public void DeleteFromWishListTest()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            loginPage.InputPasswordText("qwerty");
            loginPage.ClickOnLoginButton();

            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

            header.ClickOnWishList();

            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.RemoveProduct();


            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
            Thread.Sleep(2000);
        }


    }
}

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
            //Thread.Sleep(500);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            //Thread.Sleep(500);
            loginPage.InputPasswordText("qwerty");
            //Thread.Sleep(500);
            loginPage.ClickOnLoginButton();
            //Thread.Sleep(500);

            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            //Thread.Sleep(500);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            pageWithProduct.ClickWishListButton();

           // Thread.Sleep(500);

            header.ClickOnWishList();
            //Thread.Sleep(500);

            WishListPage wishListPage = new WishListPage(driver);
            wishListPage.RemoveProduct();

            Thread.Sleep(500);

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
            Thread.Sleep(2000);
        }

        [Test]
        public void AddToWishListTest_LoggIn()
        {
            HeaderComponent header = new HeaderComponent(driver);
            header.ClickOnMyAccount(MyAccountMenuActions.Login);
            Thread.Sleep(500);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.InputEmailText("testuser@gmail.com");
            Thread.Sleep(500);
            loginPage.InputPasswordText("qwerty");
            Thread.Sleep(500);
            loginPage.ClickOnLoginButton();
            Thread.Sleep(500);

            header.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            Thread.Sleep(500);

            PageWithProducts pageWithProduct = new PageWithProducts(driver);
            string expected = pageWithProduct.GetSelectedProductName(pageWithProduct.FirstProductName);
            pageWithProduct.ClickWishListButton();

            Thread.Sleep(2000);

            header.ClickOnWishList();
            Thread.Sleep(500);

            WishListPage wishListPage = new WishListPage(driver);
            string actual = wishListPage.GetProductName();

            Assert.AreEqual(expected, actual);

            header.ClickOnMyAccount(MyAccountMenuActions.Logout);
            Thread.Sleep(2000);

        }

    }
}

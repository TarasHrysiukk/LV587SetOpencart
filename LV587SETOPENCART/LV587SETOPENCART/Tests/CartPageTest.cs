using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    class CartPageTest
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
            driver.Navigate().GoToUrl(@"http://localhost");
        }

        [Test]
        public void Test1()
        {
            //
            HeaderComponent phones = new HeaderComponent(driver);
            phones.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            PageWithProducts phoneUnit = new PageWithProducts(driver);
            phoneUnit.ClickCartButton();
            Thread.Sleep(2000);
            //
            string act = phones.CartButtonLabelText();
            string exp = "1 item(s) - $122.00";
            //
            Assert.AreEqual(exp,act);

            //
            phones.ClickOnShoppingCartBlackButton();
            CartButtonComponent textInCart = new CartButtonComponent(driver);
            PageWithProducts textInPage = new PageWithProducts(driver);
            //
            string actu = textInCart.GetProductNameInCart();
            string expe = textInPage.GetFirstProductName();
            //
            Assert.AreEqual(expe, actu);
        }
        [Test]
        public void Test2()
        {
            HeaderComponent phones = new HeaderComponent(driver);
            phones.ClickOnMyAccount(MyAccountMenuActions.Login);
            LoginBL logIn = new LoginBL(driver);
            logIn.Login("hdhgsdh1@gmail.com", "hdhgsdh");
            phones.ChooseCategory(CategoryMenu.PhonesAndPDAs);
            PageWithProducts phoneUnit = new PageWithProducts(driver);
            Thread.Sleep(2000);

            phoneUnit.ClickCartButton();
            Thread.Sleep(2000);

            phones.ClickOnShoppingCartLink();
            Thread.Sleep(2000);

            CartPage input = new CartPage(driver);
            input.QuantityInput("55");
            input.RefreshButtonClick();
            Thread.Sleep(2000);

            CartPage inpt = new CartPage(driver);
            inpt.RemoveCircleInCartButton();
            Thread.Sleep(2000);

        }
    }
}
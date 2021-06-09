using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Threading;
using Allure.Commons;
using LV587SETOPENCART.Pages;

namespace LV587SETOPENCART.Tests
{
    class ProductComparisonTest
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
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateToURL();
        }

        [Test]
        public void CompareButtonTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            LoginBL loginBL = new LoginBL(driver);
            ProductComparisonPage productComparisonPage = new ProductComparisonPage(driver);
            PageWithProducts pageWithProducts = new PageWithProducts(driver);
           
            // Click on My Account > Login
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
           // Thread.Sleep(2000);  //Only for presentation (work Without it)

            //login
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            //Thread.Sleep(2000);  //Only for presentation (work Without it)

            headerComponent.ChooseCategory(CategoryMenu.PhonesAndPDAs);

           
            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonHTCOne);//Click copmpare HTC
            string expFirstproductName = pageWithProducts.GetSelectedProductName(pageWithProducts.FirstProductName);//Save name HTC

            Thread.Sleep(2000);  //Only for presentation
            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonIphone);//Click copmpare Iphone
            string expSecondproductName = pageWithProducts.GetSelectedProductName(pageWithProducts.SecondProductName);//save name iphone

            pageWithProducts.SelectProduct(pageWithProducts.ProductComparisonButton);//Click link compare

            string actFirstproductName = productComparisonPage.GetSelectedProductName(productComparisonPage.FirstProductName);//Save name HTC on compare page
            string actSecondproductName = productComparisonPage.GetSelectedProductName(productComparisonPage.SecondProductName);// Save name iphone on compare page

            Assert.AreEqual(expFirstproductName,actFirstproductName);//assert htc htc
            Assert.AreEqual(expSecondproductName,actSecondproductName);//assert iphone iphone

            //productComparisonPage.ClickButton(productComparisonPage.ProductComparisonButton);





        }
    }
}

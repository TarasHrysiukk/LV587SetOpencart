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
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[Comparison]")]
    [AllureDisplayIgnored]
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
        [AllureTag("OpenCart: Comparison Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vlad Vozniuk")]
        [Description("In this test, we check two fields to see if they match.")]
        public void CompareButtonTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            LoginBL loginBL = new LoginBL(driver);
            ProductComparisonPage productComparisonPage = new ProductComparisonPage(driver);
            PageWithProducts pageWithProducts = new PageWithProducts(driver);
           
            // Click on My Account > Login
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");

            headerComponent.ChooseCategory(CategoryMenu.PhonesAndPDAs);
           
            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonHTCOne);//Click copmpare HTC
            string expFirstproductName = pageWithProducts.GetSelectedProductName(pageWithProducts.FirstProductName);//Save name HTC

            Thread.Sleep(2000);  //Only for presentation
            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonIphone);//Click copmpare Iphone
            string expSecondproductName = pageWithProducts.GetSelectedProductName(pageWithProducts.SecondProductName);//save name iphone
            Thread.Sleep(2000);  //Only for presentation
            pageWithProducts.SelectProduct(pageWithProducts.ProductComparisonButton);//Click link compare

            string actFirstproductName = productComparisonPage.GetSelectedProductName(productComparisonPage.FirstProductName);//Save name HTC on compare page
            string actSecondproductName = productComparisonPage.GetSelectedProductName(productComparisonPage.SecondProductName);// Save name iphone on compare page

            Assert.AreEqual(expFirstproductName,actFirstproductName);//assert htc htc
            Assert.AreEqual(expSecondproductName,actSecondproductName);//assert iphone iphone
        }

        [Test]
        [AllureTag("OpenCart: Add Product Comparison Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vlad Vozniuk")]
        [Description("This test checks to if address book was added.")]
        public void AddProductComparisonTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            LoginBL loginBL = new LoginBL(driver);
            ProductComparisonPage productComparisonPage = new ProductComparisonPage(driver);
            PageWithProducts pageWithProducts = new PageWithProducts(driver);

            // Click on My Account > Login
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");

            headerComponent.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonHTCOne);//Click copmpare HTC
           
            Thread.Sleep(2000);  //Only for presentation

            //string actulHTC = pageWithProducts.GetAlertMessageText();
            //string expectedHTC = "Success: You have added HTC Touch HD to your product comparison!\r\n×";

            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonIphone);//Click copmpare Iphone
            Thread.Sleep(2000);  //Only for presentation

            //string actulIPhone = pageWithProducts.GetAlertMessageText();
            //string expectedIPhone = "Success: You have added iPhone to your product comparison!\r\n×";
            //Assert.AreEqual(actulHTC, expectedHTC);
            //Assert.AreEqual(actulIPhone, expectedIPhone);

            string actul = pageWithProducts.GetProductComparisonText();
            string expected = "Product Compare (2)";
            Assert.AreEqual(actul, expected);
        }

        [Test]
        [AllureTag("OpenCart: Check Product Comparison Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Vlad Vozniuk")]
        [Description("In this test I check whether the data match in our table.")]
        public void CheckComparisonTest()
        {
            HeaderComponent headerComponent = new HeaderComponent(driver);
            LoginBL loginBL = new LoginBL(driver);
            ProductComparisonPage productComparisonPage = new ProductComparisonPage(driver);
            PageWithProducts pageWithProducts = new PageWithProducts(driver);

            // Click on My Account > Login
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");

            headerComponent.ChooseCategory(CategoryMenu.PhonesAndPDAs);

            pageWithProducts.SelectProduct(pageWithProducts.CompareButtonHTCOne);//Click copmpare HTC
            
            Thread.Sleep(2000);  //Only for presentation
            
            pageWithProducts.SelectProduct(pageWithProducts.ProductComparisonButton);//Click link compare

            string actual = productComparisonPage.GetDimensions();
            string expected = "0.00cm x 0.00cm x 0.00cm";
            Assert.IsFalse(!actual.Equals(expected));
        }
    }
}

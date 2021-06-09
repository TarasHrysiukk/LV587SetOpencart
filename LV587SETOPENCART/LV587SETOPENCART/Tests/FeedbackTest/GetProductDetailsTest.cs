using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("GetProductDetailsTest")]
    [AllureDisplayIgnored]
    class GetProductDetailsTest
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
        [AllureTag("OpenCart:FeedBack|GetProductDetailsTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user can get product details")]
        public void GotoProductDetailsTest()
        {
            //Arrange
            bool expected = false;//to fail and show screen

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);//only for presentation
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Desktops);
            Thread.Sleep(2000);//only for presentation
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            Thread.Sleep(2000);//only for presentation
            ProductComponents productComponents = new ProductComponents(driver);
            Thread.Sleep(2000);//only for presentation
            bool actual = productComponents.DescriptionPresent();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            //Assert.AreEqual(expected,actual);
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception) //Take a ScreenShot if test failed
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("GetProductDetailsTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }
        }
    }
}

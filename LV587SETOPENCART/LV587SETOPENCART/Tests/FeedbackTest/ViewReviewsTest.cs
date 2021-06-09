using LV587SETOPENCART.Pages;
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
    [AllureSuite("ViewReviewsTest")]
    [AllureDisplayIgnored]
    class ViewReviewsTest
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
        [AllureTag("OpenCart:FeedBack|ViewReviewsTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks what user will see when product does not have reviews ")]
        public void ItemWithoutReviewsTest()
        {
            //Arrange

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.IsFalse(productComponents.ReviewPresent());
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ItemWithoutReviewsTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }
        }

        [Test]
        [AllureTag("OpenCart:FeedBack|ViewReviewsTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user sees product review when it exists")]
        public void ItemWithReviewTest()
        {
            //Arrange

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);//only for presentation
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Tablets);
            Thread.Sleep(2000);//only for presentation
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            Thread.Sleep(2000);//only for presentation
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.IsTrue(productComponents.ReviewPresent());
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ItemWithReviewTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }
        }
    }
}

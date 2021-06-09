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
    [AllureSuite("AddReviewTest")]
    [AllureDisplayIgnored]
    class AddReviewTest
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
        [AllureTag("OpenCart:FeedBack|AddReviewTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user sees error when he enters review without data")]
        public void ReviewWithoutDataTest()
        {
            //Arrange
            string expected = "Warning: Please select a review rating!";

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            productComponents.WriteReview("", "", RateChoose.noRate);
            string actual = productComponents.GetErrorText();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewWithoutDataTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }
        }

        [Test]
        [AllureTag("OpenCart:FeedBack|AddReviewTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user sees error when he enters review with error review text box")]
        public void ErrorReviewTextBoxTest()
        {
            //Arrange
            string expected = "Warning: Review Text must be between 25 and 1000 characters!";

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            productComponents.WriteReview("Severyn", "Text less than 25", RateChoose.excellentRate);
            string actual = productComponents.GetErrorText();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ErrorReviewTextBoxTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }

        }

        [Test]
        [AllureTag("OpenCart:FeedBack|AddReviewTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user sees error when he enters review with error name text box")]
        public void ErrorNameTextBoxTest()
        {
            //Arrange
            string expected = "Warning: Review Name must be between 3 and 25 characters!";

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            productComponents.WriteReview("", "Text more than 25 characters", RateChoose.excellentRate);
            string actual = productComponents.GetErrorText();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ErrorNameTextBoxTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }

        }

        [Test]
        [AllureTag("OpenCart:FeedBack|AddReviewTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks if user sees error when he enters review with error rate")]
        public void ErrorRateTest()
        {
            //Arrange
            string expected = "Warning: Please select a review rating!";

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            productComponents.WriteReview("Severyn", "Text more than 25 characters", RateChoose.noRate);
            string actual = productComponents.GetErrorText();

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ErrorRateTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }

        }

        [Test]
        [AllureTag("OpenCart:FeedBack|AddReviewTest")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Marian-Severyn Shevchuk")]
        [Description("This test checks what user  will see when he enters everything correctly")]
        public void ReviewTest()
        {
            //Arrange
            string expected = "Thank you for your review. It has been submitted to the webmaster for approval.";

            //Act
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(2000);//only for presentation
            HeaderComponent desktopsMenu = new HeaderComponent(driver);
            desktopsMenu.ChooseCategory(CategoryMenu.Cameras);
            Thread.Sleep(2000);//only for presentation
            PageWithProducts productPage = new PageWithProducts(driver);
            productPage.SelectProduct(productPage.FirstProductName);
            Thread.Sleep(2000);//only for presentation
            ProductComponents productComponents = new ProductComponents(driver);
            productComponents.ReviewsClick();
            Thread.Sleep(2000);//only for presentation
            productComponents.WriteReview("Severyn", "Text more than 25 characters", RateChoose.excellentRate);
            string actual = productComponents.GetSuccessText();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Sevka\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\failscreens\ScreenshotImageFormat.Png");
            }

        }
    }
}

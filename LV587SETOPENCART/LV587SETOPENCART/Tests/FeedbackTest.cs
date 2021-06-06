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
    [AllureSuite("FeedbackTest")]
    [AllureDisplayIgnored]
    class FeedbackTest
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
        //[Description("This test checks if user can get product details")]
        public void GetProductDetailsTest()
        {
            //Arrange
            bool expected = true;

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
            Assert.AreEqual(expected,actual);
        }

        [Test]
        //[Description("This test checks if user sees error when he enters review without data")]
        public void ReviewWithoutDataTest()
        {
            //Arrange
            string expected = "Warning: Please select a review rating!";

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
            productComponents.WriteReview("", "", RateChoose.noRate);
            string actual = productComponents.GetErrorText();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        //[Description("This test checks if user sees error when he enters review with error review text box")]
        public void ErrorReviewTextBoxTest()
        {
            //Arrange
            string expected = "Warning: Review Text must be between 25 and 1000 characters!";

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
            productComponents.WriteReview("Severyn", "Text less than 25", RateChoose.excellentRate);
            string actual = productComponents.GetErrorText();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        //[Description("This test checks if user sees error when he enters review with error name text box")]
        public void ErrorNameTextBoxTest()
        {
            //Arrange
            string expected = "Warning: Review Name must be between 3 and 25 characters!";

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
            productComponents.WriteReview("", "Text more than 25 characters", RateChoose.excellentRate);
            string actual = productComponents.GetErrorText();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        //[Description("This test checks if user sees error when he enters review with error rate")]
        public void ErrorRateTest()
        {
            //Arrange
            string expected = "Warning: Please select a review rating!";

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
            productComponents.WriteReview("Severyn", "Text more than 25 characters", RateChoose.noRate);
            string actual = productComponents.GetErrorText();
            Thread.Sleep(2000);//only for presentation

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [Test]
        //[Description("This test checks what user  will see when he enters everything correctly")]
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
            Assert.AreEqual(expected, actual);

        }

        [Test]
        //[Description("This test checks what user will see when product does not have reviews ")]
        public void ItemWithoutReviewsTest()
        {
            //Arrange

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

            //Assert
            Assert.IsFalse(productComponents.ReviewPresent());
        }

        [Test]
        //[Description("This test checks if user sees product review when it exists")]
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
            Assert.IsTrue(productComponents.ReviewPresent());
        }





    }
}

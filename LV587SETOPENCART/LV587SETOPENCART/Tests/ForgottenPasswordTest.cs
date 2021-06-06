using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("ForgottenPasswordTest")]
    [AllureDisplayIgnored]
    class ForgottenPasswordTest
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
        public void ForgottenPasswordPageTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            // Click on "Forgotten Password" link text and input email
            ForgottenPasswordBL forgottenPasswordBL = new ForgottenPasswordBL(driver);
            forgottenPasswordBL.ForgottenPassword("user1@gmail.com");
            //Assert
            ForgottenPasswordPage forgottenPasswordPage = new ForgottenPasswordPage(driver);
            string expRes = "An email with a confirmation link has been sent your email address.";
            var actRes = forgottenPasswordPage.AlertMessageText();
            Assert.AreEqual(expRes, actRes);
        }
    }
}

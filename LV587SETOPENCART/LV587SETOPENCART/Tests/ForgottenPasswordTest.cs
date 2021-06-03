using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
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
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);

             LoginPage login = new LoginPage(driver);
             login.ClickForgotPassword();

             ForgottenPasswordPage forgottenPasswordPage = new ForgottenPasswordPage(driver);
             forgottenPasswordPage.ForgotPasswordEmail("user1@gmail.com");
             forgottenPasswordPage.ClickOnContinueButton();
            //ForgottenPasswordBL forgottenPasswordBL = new ForgottenPasswordBL(driver);
            //forgottenPasswordBL.ForgottenPassword("user1@gmail.com"); //Failed if i use BL

            ForgottenPassSuccess forgottenPassSuccess = new ForgottenPassSuccess(driver);
            Assert.AreEqual("An email with a confirmation link has been sent your email address.", forgottenPassSuccess.AlertMessageText());
        }
    }
}

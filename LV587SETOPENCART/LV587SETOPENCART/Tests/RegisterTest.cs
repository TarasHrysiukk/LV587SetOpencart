using System;
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using Allure.Commons;

namespace LV587SETOPENCART.Tests
    
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Register Test")]
    [AllureDisplayIgnored]
    class RegisterTest
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
        [AllureTag("OpenCart: Register Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukhii Dmitro")]
        [Description("The test check that you can create new customer account (Registration)")]
        public void RegisterPageTest()
        {
            // Click on My Account > Register
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Register);

            // Execute all test methods for fill in the fields
            RegisterPage registerPage = new RegisterPage(driver);
            registerPage.SetFirstNameInputTextAndClear("Dima");
            registerPage.SetLastNameInputTextAndClear("Sukhii");
            registerPage.SetEmailInputTextAndClear("test@gmail.com");
            registerPage.SetTelephoneInputTextAndClear("0930020102");
            registerPage.SetPasswordInputTextAndClear("qwerty12345678");
            registerPage.SetPasswordConfirmInputTextAndClear("qwerty12345678");
            registerPage.ClickPrivacyPolicyCheckBox();
            registerPage.ClickSubscribeRadioButton();
            registerPage.ClickConfirmButton();

            // verify that user has been create
            string actResUserCreated = "Your Account Has Been Created!";

            AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);

            Assert.AreEqual(actResUserCreated, accountCreatedPage.AccountCreatedText());

            accountCreatedPage.ClickOnButtonContinue();

            // verify that page 'My Account' has been open
            string actResMyAccountPage = "My Account";

            MyAccountPage myAccountPage = new MyAccountPage(driver);

            Assert.AreEqual(actResMyAccountPage, myAccountPage.MyAccountText());

            
        }

    }
}

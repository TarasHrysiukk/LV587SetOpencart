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
    [AllureSuite("ChangePasswordTest")]
    [AllureDisplayIgnored]
    class ChangePasswordTest
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
        public void ChangePassword()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            //login 
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            //click password button on right side bar
            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.PasswordListButtonClick();
            //input new pass
            ChangePassword changePassword = new ChangePassword(driver);
            changePassword.InputChangePasswordText("qwertyasdf12345678");
            changePassword.ClickContinueButtonChangePassword();
            //Assert
            string expRes = "Success: Your password has been successfully updated.";
            var actRea = changePassword.AlertMessageText();
            Assert.AreEqual(expRes, actRea);

        }
    }
}

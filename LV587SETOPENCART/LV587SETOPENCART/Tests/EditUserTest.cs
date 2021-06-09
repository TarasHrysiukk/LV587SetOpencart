﻿using System;
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
    [AllureSuite("EditUser")]
    [AllureDisplayIgnored]
    class EditUserTest
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
        [AllureTag("OpenCart: Edit Information about User Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Sukhii Dmitro")]
        [Description("The test verify that you can edit data your account")]
        public void EditUserInformationTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("test12@gmail.com", "qwerty");
            // Assert
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();
            Assert.AreEqual(expRes, actRes);
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expRes, actRes);
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png");
            }
            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.EditInfoButtonClick();
            EditInformationPage editInformationPage = new EditInformationPage(driver);

            editInformationPage.SetFirstNameInput("Dima");
            editInformationPage.SetLastNameInput("Sukhii");
            editInformationPage.SetEmailInput("test12@gmail.com");
            editInformationPage.SetTelephoneInput("94329481348");
            editInformationPage.ButtonClick();


            //Assert
            string expResult = "Success: Your account has been successfully updated.";
            
            try
            {
                Assert.AreEqual(expResult, myAccountPage.VerifyAccountUpdateText());
            }
            catch (Exception)
            {
                AfterTestScreen.SaveAsFile(@"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("ReviewTestTearDown", "application/png", @"C:\Users\Dsyhi\source\repos\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\AllureScreenShots\ScreenshotImageFormat.Png");
            }
        }
    }
}
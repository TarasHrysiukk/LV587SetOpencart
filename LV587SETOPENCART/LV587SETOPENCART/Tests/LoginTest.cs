﻿using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Threading;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[LoginForm]")]
    [AllureDisplayIgnored]
    class LoginTest
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
            //driver.Navigate().GoToUrl(@"http://localhost/");
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateToURL();
        }

           [Test]
        [AllureSuite("LoginPageTest")]
        public void aLoginPageTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //Assert
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();
            Assert.AreEqual(expRes, actRes);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)
        }

        [Test]
        [AllureSuite("ForgottenPasswordPageTest")]
        public void bForgottenPasswordPageTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            // Click on "Forgotten Password" link text and input email
            ForgottenPasswordBL forgottenPasswordBL = new ForgottenPasswordBL(driver);
            forgottenPasswordBL.ForgottenPassword("user1@gmail.com");
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //Assert
            ForgottenPasswordPage forgottenPasswordPage = new ForgottenPasswordPage(driver);
            string expRes = "An email with a confirmation link has been sent your email address.";
            var actRes = forgottenPasswordPage.AlertMessageText();
            Assert.AreEqual(expRes, actRes);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
        }


        [Test]
        [AllureSuite("ChangePassword")]
        public void ChangePassword()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //login 
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            Thread.Sleep(2000);  //Only for presentation (workWithout it)

            //click password button on right side bar
            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.PasswordListButtonClick();
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //input new pass
            ChangePassword changePassword = new ChangePassword(driver);
            changePassword.InputChangePasswordText("qwertyasdf12345678");
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            changePassword.ClickContinueButtonChangePassword();
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
            //Assert
            string expRes = "Success: Your password has been successfully updated.";
            var actRea = changePassword.AlertMessageText();
            Assert.AreEqual(expRes, actRea);
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);
            Thread.Sleep(2000);  //Only for presentation (workWithout it)
        }


       
    }
}

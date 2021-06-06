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
        public void LoginPageTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            //Assert
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();
            Assert.AreEqual(expRes, actRes);

            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);
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

            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);
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

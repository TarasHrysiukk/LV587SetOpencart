using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using System.Threading;
using Allure.Commons;

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
        [AllureTag("OpenCart: Login Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can log into their account")]
        public void aLoginPageTest()//first letter a - because this test need run first
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
        [AllureTag("OpenCart: Forgotten Password Test")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can input their email to if he forgot password")]
        public void bForgottenPasswordPageTest()//first letter b - because this test need run second
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
        [AllureTag("OpenCart: Change Password Test")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can change their password")]
        public void ChangePassword()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)

            //login 
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)

            //click password button on right side bar
            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.PasswordListButtonClick();
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)

            //input new pass
            ChangePassword changePassword = new ChangePassword(driver);
            changePassword.InputChangePasswordText("qwertyasdf12345678");
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)

            changePassword.ClickContinueButtonChangePassword();
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)

            //Assert
            string expResChange = "Success: Your password has been successfully updated.";
            var actResChange = changePassword.AlertMessageText();
            Assert.AreEqual(expResChange, actResChange);
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);

            // LoginBL loginBLL = new LoginBL(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();
            Assert.AreEqual(expRes, actRes);
            //Thread.Sleep(2000);  //Only for presentation (workWithout it)
        }
    }
}

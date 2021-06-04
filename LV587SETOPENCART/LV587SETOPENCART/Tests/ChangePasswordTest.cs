using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
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
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345");

            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.PasswordListButtonClick();

           // ChangePassword changePassword = new ChangePassword(driver);
           // changePassword.InputChangePasswordText("qwertyasdf12345678");
            
          //  changePassword.ClickContinueButtonChangePassword();
          //fail

        }
    }
}

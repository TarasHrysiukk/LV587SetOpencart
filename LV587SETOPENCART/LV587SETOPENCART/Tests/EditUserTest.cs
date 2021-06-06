using System;
using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace LV587SETOPENCART.Tests
{
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
        public void EditUserInformationTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("test12@gmail.com", "qwerty");
            //Assert
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();
            Assert.AreEqual(expRes, actRes);
            RightSideBar rightSideBar = new RightSideBar(driver);
            rightSideBar.EditInfoButtonClick();
            EditInformationPage editInformationPage = new EditInformationPage(driver);

            editInformationPage.SetFirstNameInput("Dima");
            editInformationPage.SetLastNameInput("Sukhii");
            editInformationPage.SetEmailInput("test12@gmail.com");
            editInformationPage.SetTelephoneInput("94329481348");
            editInformationPage.ButtonClick();

            Assert.AreEqual("Success: Your account has been successfully updated.", myAccountPage.VerifyAccountUpdateText());
        }
    }
}

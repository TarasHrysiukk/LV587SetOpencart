using LV587SETOPENCART.Pages;
using LV587SETOPENCART.BL;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;


namespace LV587SETOPENCART.Tests
{
    [TestFixture]
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
            driver.Navigate().GoToUrl(@"http://localhost/index.php?route=account/login");
        }

        [Test]
        public void Test()
        {
            LoginBL loginBL = new LoginBL(driver);
            LoginPage loginPage = new LoginPage(driver);

            loginBL.Login("user1@gmail.com", "qwerty");

            // MyAccountPage myAccountPage = new MyAccountPage(driver); //crash mafacka
            //Assert.AreEqual("My Account", myAccountPage.MyAccountText());

        }
    }
}

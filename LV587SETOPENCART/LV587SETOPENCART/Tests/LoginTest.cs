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
        IWebDriver driver = new ChromeDriver();
        //LoginPage loginPage = new LoginPage(driver);
        [Test]
        public void Test()
        {
            LoginBL loginBL = new LoginBL(driver);
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            loginBL.Login("user1@gmail.com", "qwerty");

            Assert.AreEqual("My Account", myAccountPage.MyAccountText());

        }
    }
}

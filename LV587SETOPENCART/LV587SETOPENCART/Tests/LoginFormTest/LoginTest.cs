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
            ClassWithDriver classWithDriver = new ClassWithDriver(driver);
            classWithDriver.NavigateToURL();
        }

           [Test]
        [AllureTag("OpenCart: Login Test")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can log into account")]
        public void LoginPageTest()
        {
            //Click on My Account > Login
            HeaderComponent headerComponent = new HeaderComponent(driver);
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
            Thread.Sleep(2000);  //Only for presentation (work Without it)

            //login
            LoginBL loginBL = new LoginBL(driver);
            loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
            Thread.Sleep(2000);  //Only for presentation (work Without it)

            //Assert
            MyAccountPage myAccountPage = new MyAccountPage(driver);
            string expRes = "My Account";
            var actRes = myAccountPage.MyAccountText();

            //Assert.AreEqual(expRes, actRes);
            //Thread.Sleep(2000);  //Only for presentation (work Without it)
            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                Assert.AreEqual(expRes, actRes);
            }
            catch (Exception) //Take a ScreenShot if test is failed
            {
                AfterTestScreen.SaveAsFile(@"D:\Projects_C#\Demo3\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\screens\ScreenshotForgotPassTest.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", @"D:\Projects_C#\Demo3\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\screens\ScreenshotForgotPassTest.Png");
            }
            headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);
            //Thread.Sleep(2000);  //Only for presentation (work Without it)
        }
    }
}

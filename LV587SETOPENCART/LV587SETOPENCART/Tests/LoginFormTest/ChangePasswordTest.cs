using Allure.Commons;
using LV587SETOPENCART.BL;
using LV587SETOPENCART.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace LV587SETOPENCART.Tests
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("[LoginForm]")]
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
        [AllureTag("OpenCart: Change Password Test")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Taras Hrysiuk")]
        [Description("This test checks to if user can change their password")]
        public void ChangePasswordPageTest()
        {

            Screenshot AfterTestScreen = ((ITakesScreenshot)driver).GetScreenshot();
            try
            {
                //Click on My Account > Login
                HeaderComponent headerComponent = new HeaderComponent(driver);
                headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
                //Thread.Sleep(2000);  //Only for presentation (works Without it)

                //login 
                LoginBL loginBL = new LoginBL(driver);
                loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
                Thread.Sleep(2000);  //Only for presentation (works Without it)

                //click password button on right side bar
                RightSideBar rightSideBar = new RightSideBar(driver);
                rightSideBar.PasswordListButtonClick();
                Thread.Sleep(2000);  //Only for presentation (works Without it)

                //input new pass
                ChangePassword changePassword = new ChangePassword(driver);
                changePassword.InputChangePasswordText("qwertyasdf12345678");
                Thread.Sleep(2000);  //Only for presentation (works Without it)

                changePassword.ClickContinueButtonChangePassword();
                Thread.Sleep(2000);  //Only for presentation (works Without it)

                //Assert
                string expRes = "Success: Your password has been successfully updated.";
                var actRes = changePassword.AlertMessageText();

                //Assert.AreEqual(expResChange, actResChange);
                Assert.AreEqual(expRes, actRes);

                Thread.Sleep(2000);  //Only for presentation (works Without it)
                headerComponent.ClickOnMyAccount(MyAccountMenuActions.Logout);

                // LoginBL loginBLL = new LoginBL(driver);
                headerComponent.ClickOnMyAccount(MyAccountMenuActions.Login);
                loginBL.Login("user1@gmail.com", "qwertyasdf12345678");
                MyAccountPage myAccountPage = new MyAccountPage(driver);
                string expResChange = "My Account";
                var actResChange = myAccountPage.MyAccountText();
                Assert.AreEqual(expResChange, actResChange);
            }

            catch (Exception) //Take a ScreenShot if test is failed
            {
                AfterTestScreen.SaveAsFile(@"D:\Projects_C#\Demo3\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\allureScreens\ScreenshotChangePassTest.Png", ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("TearDown", "application/png", @"D:\Projects_C#\Demo3\LV587SetOpencart\LV587SETOPENCART\LV587SETOPENCART\bin\Debug\net5.0\allureScreens\ScreenshotChangePassTest.Png");
            }
        }
    }
}